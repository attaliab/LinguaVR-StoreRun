using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class spanishGroceryListManager : MonoBehaviour
{
    public GameObject GroceryList;
    public GameObject[] item;
    
// Text Component
    TextMeshProUGUI textmeshpro_item_text;
    TextMeshProUGUI textmeshpro_item_text2;
    public GameObject[] mark;

    public List<string> modifiableList;
    public GameObject reviewScreenUI;
    public GameObject[] completionEnglishItems;


        // Function to get 2 similar lists: a list of random grocery items for the backend and another list to gather their textmeshpro component to be displayed in UI
        public (List<string> modifiableList, List<string> displayedList, List<string> englishList) randomFoodList()
        {
        // Get the Read component from GroceryList object
        Read allGroceryItems = GroceryList.GetComponent<Read>();
        
        // Get the JSON full item list from the Read script
        (List<string> frenchStrings, List<string> englishStrings, List<string> spanishStrings, List<string> germanStrings) foodList = allGroceryItems.jsonDataList();
        // Get the RandomNumber script from the GroceryList object
        spanishRandomNumber randList = GroceryList.GetComponent<spanishRandomNumber>();
        
        List<int> nums = randList.RandomList();

        // List<string> randomizedFoodList = new List<string>();
        List<string> displayedList = new List<string>();
        // List for english translation to be shown in reviewScreenUI
        List<string> englishList = new List<string>();
        
        modifiableList.Clear();
        englishList.Clear();

        for (int i = 0; i < 5; i++)
        {
            textmeshpro_item_text = item[i].GetComponent<TextMeshProUGUI>();
            textmeshpro_item_text2 = completionEnglishItems[i].GetComponent<TextMeshProUGUI>();
            int numIndex = nums[i];

            textmeshpro_item_text.text = foodList.spanishStrings[numIndex];
            textmeshpro_item_text2.text  = foodList.englishStrings[numIndex];
            Debug.Log(textmeshpro_item_text.text);


            string text = textmeshpro_item_text.text;
            string text2 = textmeshpro_item_text2.text;

            displayedList.Add(text);
            modifiableList.Add(text);
            englishList.Add(text2);
            if (modifiableList.Count == 5)
            {
                break;
            }
        }
        return (modifiableList, displayedList, englishList);
        }




    void Start()
    {
        foreach(GameObject markObject in mark)
        {
            markObject.SetActive(false);
        }
    }
}
