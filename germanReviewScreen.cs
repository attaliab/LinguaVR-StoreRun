using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class germanReviewScreen : MonoBehaviour
{
    public GameObject GroceryList;
    public GameObject reviewScreenUI;
    public GameObject[] uiItems;
    public GameObject[] uiItemsEnglish;
    TextMeshProUGUI textmeshproItemText;
    TextMeshProUGUI textmeshproItemText2;
    public GameObject effectObject;
    public AudioSource winningSound;

    public void Start()
    {

        reviewScreenUI.SetActive(false);
        displayListToUI();
        effectObject.SetActive(false);

    }


    public (List<string> reviewScreenList, List<string> reviewScreenListEnglish) displayListToUI()
    {
        List<string> modifiableList = new List<string>();
        List<string> displayedList = new List<string>();
        List<string> englishList = new List<string>();
        germanGroceryListManager germanGroceryListManager = GroceryList.GetComponent<germanGroceryListManager>();
        (modifiableList, displayedList, englishList) = germanGroceryListManager.randomFoodList();

        
        var listLength = displayedList.Count;
        List<string> reviewScreenList = new List<string>();
        List<string> reviewScreenListEnglish = new List<string>();
        for (int i=0; i < listLength; i++)
        {
            textmeshproItemText = uiItems[i].GetComponent<TextMeshProUGUI>();
            textmeshproItemText2 = uiItemsEnglish[i].GetComponent<TextMeshProUGUI>();
            textmeshproItemText.text = displayedList[i];
            textmeshproItemText2.text = englishList[i];
            string text = textmeshproItemText.text;
            string textEnglish = textmeshproItemText2.text;
            reviewScreenList.Add(text);
            reviewScreenListEnglish.Add(textEnglish);
        }
        return (reviewScreenList, reviewScreenListEnglish);
    }


    public void enableCompletionUI()
    {
        reviewScreenUI.SetActive(true);
        effectObject.SetActive(true);
            ParticleSystem confetti = GameObject.Find("Particle System_7").GetComponent<ParticleSystem>();
            var emission = confetti.emission;
            emission.enabled = true;
            confetti.Play();
            winningSound.Play();

    } 
}
