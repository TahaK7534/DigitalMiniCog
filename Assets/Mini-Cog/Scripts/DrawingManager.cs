using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.UniversityOfAlberta.product
{
    public class DrawingManager : MonoBehaviour
    {
        public GameObject linePrefab; 
        public Collider2D drawingAreaCollider;
        
        LineDrawing activeLine;

        void Update()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
