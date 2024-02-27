# LinguaVR-StoreRun

These are the scripts used in my language-learning VR game, LinguaVR (Level: Store Run). These scripts use C# with Unity API and are applied to the game.

************************************ EXPLANATION OF THE SCRIPTS ************************************

GetLanguage.cs - Loads the scene of the language the user selects at the start of the game

groceryItems.json - Contains all the fruits and vegetables in the game, listed in English, Spanish, French, and German
Read.cs - Deserializes data from the JSON file to be used with other C# scripts
[scene]RandomNumber.cs - Gets a specified amount of random numbers and puts it in an arraylist
[scene]GroceryListManager.cs - Takes the list of random numbers from RandomNumber.cs and grabs a random fruit or vegetable from the list using the random array number and puts it in a new list. This list is then displayed to the user's assigned grocery list UI and the English translation on the Review Screen (shown at the completion of the activity)
[scene]ReviewScreen.cs - Takes the list of groceries in the user's selected language and the english translation of the word and displays it to UI to come up at the completion of the activity
[scene]ScoreCheck.cs - Checks whether the item the user put in the basket is in the grocery list. If the item is in the list, it check it off the grocery list, displays a plays a confetti animation, and plays a sound. If the item is not in the list, it destroys the object and plays a sound to signal the user is incorrect

OnButtonPress.cs - Displays the select language translation of the item that the user is currently holding and plays the pronunciation of it. Also keeps the translation card above the held item during motion

HelperTips.cs - Display a tip card the first time the user grabs an item and tells them what button to press to hear the pronunciation and see the word

PlayerPrefs.json - Stores the player preferences: Locomotion type, music volume, SFX volume
PlayerData.cs - Serializes JSON keys
PlayerPreferences.cs - Handles loading and saving selected preferences to/from PlayerPrefs.json file

LocomotionToggle.cs - Enables teleportation locomotion or continuous movement locomotion
