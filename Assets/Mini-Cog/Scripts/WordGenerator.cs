using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Meta.WitAi.TTS.Utilities;
using System.Text.RegularExpressions;
using UnityEngine.UI;  // Add this for removing tags

namespace com.UniversityOfAlberta.product
{
    public class WordGenerator : MonoBehaviour
    {
        [SerializeField] private TTSSpeaker Speaker;
        public List<List<string>> listOfStringLists = new List<List<string>>()
        {
            new List<string> { "Banana", "Sunrise", "Chair" },
            new List<string> { "Leader", "Season", "Table" },
            new List<string> { "Village", "Kitchen", "Baby" },
            new List<string> { "River", "Nation", "Finger" },
            new List<string> { "Captain", "Garden", "Picture" },
            new List<string> { "Daughter", "Heaven", "Mountain" }
        };

        public TextMeshProUGUI Word1;
        public TextMeshProUGUI Word2;
        public TextMeshProUGUI Word3;

        public static List<string> PickedList;

        public TextMeshProUGUI TextBox;

        public Button StartButton;

        private TextMeshProUGUI StartButtonText;


        void Start()
        {
            StartButtonText = StartButton.GetComponentInChildren<TextMeshProUGUI>();
            StartButton.onClick.AddListener(SayWords);


            List<string> randomList = PickRandomList();

            Word1.text = randomList[0];
            Word2.text = randomList[1];
            Word3.text = randomList[2];

            // Remove rich text tags from TextBox text before speaking
            string cleanText = RemoveRichTextTags(TextBox.text);
            Speaker.Speak(cleanText);
           
        }

        // Method to remove rich text tags
        string RemoveRichTextTags(string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        List<string> PickRandomList()
        {
            int randomIndex = Random.Range(0, listOfStringLists.Count);
            PickedList = listOfStringLists[randomIndex];
            return listOfStringLists[randomIndex];
        }

        public void SayWords()
        {
            StartButtonText.text = "Repeat";

            StartButton.onClick.RemoveAllListeners();
            StartButton.onClick.AddListener(RepeatWords);

            Speaker.Speak("Please listen carefully. I am going to say three words that I want you to repeat back to me now and try to remember. The words are");
            Speaker.SpeakQueued(PickedList[0] + ",");
            Speaker.SpeakQueued(PickedList[1] + ",");
            Speaker.SpeakQueued(PickedList[2] + ",");

            Speaker.SpeakQueued("Now please press the mic button and repeat the words.");

        }

       public void RepeatWords()
        {
            Debug.Log("RepeatWords called"); 
            Speaker.SpeakQueued(PickedList[0] + ",");
            Speaker.SpeakQueued(PickedList[1] + ",");
            Speaker.SpeakQueued(PickedList[2] + ",");
            Speaker.SpeakQueued("Now please press the mic button and repeat the words");
        }

        public void RepeatInstructions()
        {
            string cleanText = RemoveRichTextTags(TextBox.text);
            Speaker.Speak(cleanText);
        }
    }
}
