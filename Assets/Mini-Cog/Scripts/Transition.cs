using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.UniversityOfAlberta.product
{
    public class Transition : MonoBehaviour
    {
        public string sceneToLoad;

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
