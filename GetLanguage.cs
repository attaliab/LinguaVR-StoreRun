using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Autohand;

public class GetLanguage : MonoBehaviour
{
    // BUTTONS
    public Button spanishButton;
    public Button frenchButton;
    public Button germanButton;
    public Button playButton;
    // UI ELEMENTS
    public GameObject groceryList;
    public GameObject reviewUI;
    public GameObject welcomeScreen;

    
    public GameObject autoHandPlayerObj;

    void Awake()
    {
        // DISABLE PLAYER MOVEMENT
        AutoHandPlayer autoHandPlayer = autoHandPlayerObj.GetComponent<AutoHandPlayer>();
        autoHandPlayer.useMovement = false;
    }
       void Start()
    {
        PlayerPreferences playerPreferences = welcomeScreen.GetComponent<PlayerPreferences>();
        playerPreferences.LoadFromJson();

        // DISABLE PLAY BUTTON IN start-default SCENE
		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;
        if(sceneName == "start-default")
        {
            playButton.interactable = false;
        }
    }



    public void OnSpanishButtonClick()
    {
        SceneManager.LoadScene("spanish-lingua");
    }

    public void OnFrenchButtonClick()
    {
        SceneManager.LoadScene("french-lingua");
    }

    public void OnGermanButtonClick()
    {
        SceneManager.LoadScene("german-lingua");
    }

    public void closeWelcomeScreen()
    {
        // ENABLE PLAYER MOVEMENT
        AutoHandPlayer autoHandPlayer = autoHandPlayerObj.GetComponent<AutoHandPlayer>();
        autoHandPlayer.useMovement = true;

        // LOAD PLAYER PREFS WHEN PRESSING PLAY
        PlayerPreferences playerPreferences = welcomeScreen.GetComponent<PlayerPreferences>();
        playerPreferences.LoadFromJson();

        Destroy(welcomeScreen);
    }
}

