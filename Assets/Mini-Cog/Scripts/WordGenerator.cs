using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this to use TextMeshPro
using Meta.WitAi.TTS.Utilities;

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
        public GameObject WordBoxes;
        public static List<string> PickedList;
        

        void Start()
        {

            int index = 0;
            // Pick a random list
            List<string> randomList = PickRandomList();

            // Iterate through the children of WordBoxes
            foreach (Transform child in WordBoxes.transform)
            {
                {
                    foreach (Transform subChild in child)
                    {
                        // Find the TMP_InputField component on the subChild
                        TMP_InputField inputField = subChild.GetComponent<TMP_InputField>();
                        if (inputField != null)
                        {
                            // Set the text from the list
                            if (index < randomList.Count)
                            {
                                inputField.text = randomList[index];
                                index++;
                            }
                        }
                    }
                }
                
            }

            Speaker.Speak("Please listen carefully and memorize the following words");
            Speaker.SpeakQueued(randomList[0]);

            Speaker.SpeakQueued(randomList[1]);


            Speaker.SpeakQueued(randomList[2]);

            
        }

        List<string> PickRandomList()
        {
            int randomIndex = Random.Range(0, listOfStringLists.Count);
            PickedList = listOfStringLists[randomIndex];
            return listOfStringLists[randomIndex];
        }       



        public void RepeatWords() {
            Speaker.Speak("Please listen carefully and memorize the following words");
            Speaker.SpeakQueued(PickedList[0]);
            Speaker.SpeakQueued(PickedList[1]);
            Speaker.SpeakQueued(PickedList[2]);

        }
    }
}
