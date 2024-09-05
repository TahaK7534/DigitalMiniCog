using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace com.UniversityOfAlberta.product
{
    public class LineDrawing : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        List<Vector2> points;

        public void UpdateLine(Vector2 position) {
            if (points == null) {
                points = new List<Vector2>();
                SetPoint(position);
                return;
            }
            if (Vector2.Distance(points.Last(), position) > .08f) 
            {
                SetPoint(position);
            }
        }

        void SetPoint(Vector2 point) {
            points.Add(point);

            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPosition(points.Count -1, point);
        }
    }
}
