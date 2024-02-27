using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ScoreCheck : MonoBehaviour
{
    public GameObject effectObject;
    public GameObject ScoreArea;
    public GameObject GroceryList;
    public GameObject[] mark;
    public AudioSource successSound;
    public AudioSource incorrectSound;


    public float activeDuration;
    private GroceryListManager groceryList;
    List<string> editableList;
    List<string> groceryListItems;

    public GameObject reviewScreenUI;




    void Awake()
    {
        groceryList = GroceryList.GetComponent<GroceryListManager>();
        if (groceryList != null)
        {
        editableList = groceryList.modifiableList;
        var result = groceryList.randomFoodList();
        groceryListItems = result.displayedList;
        }
    }


    void Start()
    {
        effectObject.SetActive(false);
    }

   

    void OnTriggerEnter(Collider otherCollider)
    {
        Read allGroceryItems = GroceryList.GetComponent<Read>();
        (List<string> frenchStrings, List<string> englishStrings, List<string> spanishStrings, List<string> germanStrings) foodList = allGroceryItems.jsonDataList();

        List <string> frenchList = foodList.frenchStrings;

         //*****************************************************************

        // GET NAME OF COLLIDER
            string colliderName = otherCollider.gameObject.name;
            GameObject colliderObject = otherCollider.gameObject;
            XRGrabInteractable grabInteractable = colliderObject.GetComponent<XRGrabInteractable>();
            Debug.Log("COLLIDER NAME: " + colliderName);
            Debug.Log("COLLIDER OBJECT: " + colliderObject);

// Check if the collider is on the JSON list
        if(frenchList.Contains(colliderName))
        {
            // CHECK IF THE GROCERY LIST DOES NOT CONTAIN THE ITEM PUT INTO THE BASKET
            if (!groceryListItems.Contains(colliderName))
            {
                // DESTROY AND DISABLE OBJECT
                Destroy(otherCollider.gameObject);
                incorrectSound.Play();
                otherCollider.gameObject.SetActive(false);

            } else
            {
                // SET PARTICLE SYSTEM ACTIVE, ENABLE EMISSION, PLAY PARTICLE SYSTEM
                effectObject.SetActive(true);
                ParticleSystem confetti = GameObject.Find("Particle System_12").GetComponent<ParticleSystem>();
                var emission = confetti.emission;
                emission.enabled = true;
                confetti.Play();
                successSound.Play();

                // CHECK THE ITEM OFF UI LIST
                int colliderLocation = groceryListItems.IndexOf(colliderName);
                GameObject checkmarkToActivate = mark[colliderLocation];
                checkmarkToActivate.SetActive(true);

                // DISABLE THE GRAB INTERACTABLE
                grabInteractable.enabled = false;

                // REMOVE THE NAME FROM THE BACKEND LIST
                editableList.Remove(colliderName);
                Debug.Log("EDITABLE LIST IS not EQUAL TO ZERO: " + editableList.Count);
                checkEditableList();
            }
        } else
        {
            // DO NOTHING IF THE COLIDER IS NOT ON THE JSON LIST. THIS PREVENTS THE GAME FROM CRASHING.
            return;
        }
    }
    
    private void checkEditableList()
    {
          if (editableList.Count == 0)
            {
                Debug.Log("EDITABLE LIST IS EQUAL TO ZERO: " + editableList.Count);
                reviewScreen reviewScreen = reviewScreenUI.GetComponent<reviewScreen>();
                reviewScreen.enableCompletionUI();
                if (reviewScreenUI.activeSelf == true)
                {
                    Debug.Log("UI IS ACTIVE");
                }
            } else
            {
                Debug.Log("EDITABLE LIST NOT EMPTY");
            }
    }
}

