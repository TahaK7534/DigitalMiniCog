using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi.TTS.Utilities;
using TMPro;
using System;


namespace com.UniversityOfAlberta.product
{
    public class TextToSpeach : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField] private TTSSpeaker Speaker;
        public TextMeshProUGUI MyText;


        

        public void SpeakText() {
            Speaker.Speak(MyText.text);
        }

       
    }
}
