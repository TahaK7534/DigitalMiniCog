using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.UniversityOfAlberta.product
{
    public class DrawingManager : MonoBehaviour
    {
        public GameObject linePrefab; 
        public Collider2D drawingAreaCollider;
        public Camera providedCamera; 
        private List<GameObject> drawnLines = new List<GameObject>(); // Track drawn lines
        LineDrawing activeLine;

        void Update()
        {
            // Check if the provided camera is assigned
            if (providedCamera == null)
            {
                Debug.LogError("No camera assigned. Please assign a camera to the DrawingManager.");
                return;
            }

            // Ensure we are handling valid mouse position values
            Vector3 screenPosition = Input.mousePosition;
            if (float.IsNegativeInfinity(screenPosition.x) ||
                float.IsNegativeInfinity(screenPosition.y) ||
                float.IsNegativeInfinity(screenPosition.z))
            {
                return; // Exit early if screen position is invalid
            }

            // Convert screen position to world position using the provided camera
            Vector2 mousePosition = providedCamera.ScreenToWorldPoint(screenPosition);

            if (Input.GetMouseButtonDown(0)) 
            {
                if (IsPointInCollider(mousePosition))
                {
                    GameObject newLine = Instantiate(linePrefab);
                    activeLine = newLine.GetComponent<LineDrawing>();
                    drawnLines.Add(newLine); // Add new line to the list
                }
            }

            if (Input.GetMouseButtonUp(0)) 
            {
                activeLine = null;
            }

            if (activeLine != null && IsPointInCollider(mousePosition))
            {
                activeLine.UpdateLine(mousePosition);
            }

            // Undo button logic (e.g., Spacebar for testing)
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                UndoLastLine();
            }
        }

        bool IsPointInCollider(Vector2 point)
        {
            return drawingAreaCollider.OverlapPoint(point);
        }

        // Method to undo the last line
        public void UndoLastLine()
        {
            if (drawnLines.Count > 0)
            {
                GameObject lastLine = drawnLines[drawnLines.Count - 1];
                drawnLines.RemoveAt(drawnLines.Count - 1); // Remove last line from the list
                Destroy(lastLine); // Destroy the last line object
            }
        }
    }
}
