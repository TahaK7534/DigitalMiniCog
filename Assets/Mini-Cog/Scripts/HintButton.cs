using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.UniversityOfAlberta.product
{
    public class HintButton : MonoBehaviour
    {

        public GameObject Hints;
        void Start()
        {
        
        }

        public void HintDisplay() {
                Hints.gameObject.SetActive(true); 
              
        }

        public void HintHide() {
                Hints.gameObject.SetActive(false); 
            
        }
    }
}
