using System.Collections.Generic;
using UnityEngine;

public class spanishRandomNumber : MonoBehaviour
{
    public GameObject GroceryList;
    
    List<int> ListRandNums = new List<int>();
     public List<int> RandomList()
        {
            // Create an instance of the Read script
            Read allGroceryItems = GroceryList.GetComponent<Read>(); 
            // Get the JSON data from the Read script instance in the GroceryList object in Unity
            (List<string> frenchStrings, List<string> englishStrings, List<string> spanishStrings, List<string> germanStrings) foodList = allGroceryItems.jsonDataList();

            // Create an instance of GroceryListManager
            spanishGroceryListManager spanishGroceryListManager = GroceryList.GetComponent<spanishGroceryListManager>();
            // Get the itemList from GroceryListManager
            GameObject[] itemList = spanishGroceryListManager.item;

            // For the amount of items in the itemList assign a random number to a list of random numbers
            for( int i = 0; i < itemList.Length; i++)
            {
            int RandNum = Random.Range(0, foodList.spanishStrings.Count);
            // Prevent duplicates from being added to the list of random numbers
            if (!ListRandNums.Contains(RandNum))
            {
            ListRandNums.Add(RandNum);
            }
            else
            {
                i -= 1;
            }
           } 

        // Debug.Log(ListRandNums);
        return ListRandNums;
        }
}