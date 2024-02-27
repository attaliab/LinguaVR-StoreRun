using UnityEngine;
using TMPro;
using Autohand.Demo;

public class LocomotionToggle : MonoBehaviour
{
    public GameObject teleportation;
    public TMP_Dropdown dropdown;
    public int locomotionSetting;
    public GameObject autoHandPlayerObj;


    public void toggleLocomotionType()
    {
        if(dropdown.value == 1)
        {
            // TELEPORTATION SELECTION
            teleportation.SetActive(true);
            Debug.Log("LOCOMOTION = teleportation");
            XRHandPlayerControllerLink xrHandPlayerControllerLink = autoHandPlayerObj.GetComponent<XRHandPlayerControllerLink>();
            xrHandPlayerControllerLink.enabled = false;
        } else
        {
            // CONTINUOUS MOVEMENT SELECTION
            teleportation.SetActive(false);
            Debug.Log("LOCOMOTION = continuous movement");
        }
    }
}
