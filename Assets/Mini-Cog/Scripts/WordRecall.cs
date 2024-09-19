using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.UniversityOfAlberta.product
{
    public class WordRecall : MonoBehaviour
    {
       public Button NextPage;

       public Text SpeachToText;

       public int numberofRepeats = 0;

       public Text Mic;

       private int Activate = 0;


       void Start()
        {
        NextPage.interactable = false;
        }

       void Update() {
        
        if (Mic.text == "Activate" && Activate == 0){
            Activate = 1;
        }
        if (Mic.text == "Deactivate" && Activate == 1) {
            Activate = 0;
            WordCompare();
        }
       }

       public void WordCompare() {
         string speechText = SpeachToText.text.ToLower();

            // Variable to track if all words are found
            bool allWordsFound = true;

            // Loop through each word in the PickedList
            foreach (var word in WordGenerator.PickedList)
            {
                // Convert each word to lowercase for case-insensitive comparison
                string lowerCaseWord = word.ToLower();

                // Check if the word exists in the speech text
                if (!speechText.Contains(lowerCaseWord))
                {
                    // If any word is not found, set flag to false
                    allWordsFound = false;
                    break;  // Exit the loop since not all words are found
                }
            }

            // Result of comparison
            if (allWordsFound || numberofRepeats == 2)
            {
                NextPage.interactable = true;

            }
            numberofRepeats +=1;
        }
       }

    }

