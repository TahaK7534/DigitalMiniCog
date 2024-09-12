using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace com.UniversityOfAlberta.product
{
    public class NumberScreenshots : MonoBehaviour
    {
        public List<BoxCollider2D> boxColliders; 

        public void Screenshot()
        {
            StartCoroutine(CoroutineScreenshot());
        }

        private IEnumerator CoroutineScreenshot() 
        {
            yield return new WaitForEndOfFrame();

            foreach (var collider in boxColliders)
            {
                // Calculate the collider's screen space rectangle
                Rect rect = GetRectFromCollider(collider);

                // Capture the screenshot
                Texture2D screenshotTexture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.ARGB32, false);
                screenshotTexture.ReadPixels(rect, 0, 0);
                screenshotTexture.Apply();

                byte[] byteArray = screenshotTexture.EncodeToPNG();
                string filePath = Path.Combine(Application.persistentDataPath, "ColliderScreenshot_" + collider.gameObject.name + ".png");
                File.WriteAllBytes(filePath, byteArray);


                // Clean up
                Destroy(screenshotTexture);
            }
        }

        private Rect GetRectFromCollider(BoxCollider2D collider)
        {
            // Get collider bounds in world space
            Bounds bounds = collider.bounds;

            // Get screen space corners of the collider bounds
            Vector3[] screenCorners = new Vector3[4];
            screenCorners[0] = Camera.main.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.min.y, 0));
            screenCorners[1] = Camera.main.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.min.y, 0));
            screenCorners[2] = Camera.main.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.max.y, 0));
            screenCorners[3] = Camera.main.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.max.y, 0));

            // Calculate the screen space rectangle
            float xMin = Mathf.Min(screenCorners[0].x, screenCorners[1].x, screenCorners[2].x, screenCorners[3].x);
            float xMax = Mathf.Max(screenCorners[0].x, screenCorners[1].x, screenCorners[2].x, screenCorners[3].x);
            float yMin = Mathf.Min(screenCorners[0].y, screenCorners[1].y, screenCorners[2].y, screenCorners[3].y);
            float yMax = Mathf.Max(screenCorners[0].y, screenCorners[1].y, screenCorners[2].y, screenCorners[3].y);

            return new Rect(xMin, yMin, xMax - xMin, yMax - yMin);
        }
    }
}
