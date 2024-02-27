using System;
using System.Collections.Generic;
using UnityEngine;

public class Read : MonoBehaviour
{
    public TextAsset jsonData;
    public FoodList items = new FoodList();

    [System.Serializable]
    public class Items
    {
        public string french;
        public string english;
        public string spanish;
        public string german;
    }

    [System.Serializable]
    public class FoodList
    {
        public List<Items> items;
    }

    public (List<string> frenchStrings, List<string> englishStrings, List<string> spanishStrings, List<string> germanStrings) jsonDataList()
    {
        var jsonDataText = jsonData.text;
        items = JsonUtility.FromJson<FoodList>(jsonDataText);
        List<string> frenchStrings = new List<string>();
        List<string> englishStrings = new List<string>();
        List<string> spanishStrings = new List<string>();
        List<string> germanStrings = new List<string>();
        for (int i = 0; i < items.items.Count; i++)
        {
            frenchStrings.Add(items.items[i].french);
            englishStrings.Add(items.items[i].english);
            spanishStrings.Add(items.items[i].spanish);
            germanStrings.Add(items.items[i].german);
        }


        return (frenchStrings, englishStrings, spanishStrings, germanStrings);

    }


}
