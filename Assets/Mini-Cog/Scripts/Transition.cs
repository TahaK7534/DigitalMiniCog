using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.UniversityOfAlberta.product
{
    public class Transition : MonoBehaviour
    {
        // Public string to specify the scene name in the Inspector
        public string sceneToLoad;

        // Function to call the scene
        public void LoadScene()
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogError("No scene specified to load.");
            }
        }
    }
}
