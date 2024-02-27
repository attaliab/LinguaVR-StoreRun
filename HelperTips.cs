using Autohand;
using UnityEngine;

public class HelperTips : MonoBehaviour
{
    bool hasBeenGrabbed = false;
    public GameObject tutorialTooltip;

    public Hand rightHand;
    public Hand leftHand;

    public Camera head;
    public float xOffset = 1.0f;



    void Update()
    {
        Grabbable grabbable = GetComponent<Grabbable>();
        if(tutorialTooltip != null)
        {
            if(!hasBeenGrabbed && (grabbable.IsHolding(leftHand) || grabbable.IsHolding(rightHand)))
            {
                hasBeenGrabbed = true;
                showTutorialTooltip();
            }
        }
        else
        {
            Debug.Log("Tutorial tip null");
        }
    }

    public void destroyTutorialTooltip()
    {
        Destroy(tutorialTooltip);
    }

    void showTutorialTooltip()
    {
        tutorialTooltip.SetActive(true);
    }

}
