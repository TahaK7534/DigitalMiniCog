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
        }

        bool IsPointInCollider(Vector2 point)
        {
            return drawingAreaCollider.OverlapPoint(point);
        }
    }
}
