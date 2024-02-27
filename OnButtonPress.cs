using Autohand;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using JetBrains.Annotations;


public class OnButtonPress : MonoBehaviour
{
    [Tooltip("Input action to check")]
    public InputAction action = null;

    [Tooltip("Reference to the tooltip GameObject")]
    public GameObject tooltip;


    public AudioSource sound;
    
    public Hand rightHand;
    public Hand leftHand;
    public float tooltipOffset = 0.2f;

    private bool isTooltipActive = false;
    public XRBaseInteractor interactor;


    
    private void Awake()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        action.started += Pressed;
        action.canceled += Released;
        grabInteractable.selectEntered.AddListener((XRBaseInteractor) => OnSelectEnter(interactor));
        grabInteractable.selectExited.AddListener((XRBaseInteractor) => OnSelectExit(interactor));
    }

private void OnDestroy()
{
    XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
    action.started -= Pressed;
    action.canceled -= Released;
    grabInteractable.selectEntered.RemoveListener((XRBaseInteractor) => OnSelectEnter(interactor));
    grabInteractable.selectExited.RemoveListener((XRBaseInteractor) => OnSelectExit(interactor));
}

private void Update()
    {
        Grabbable grabbable = GetComponent<Grabbable>();
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (isTooltipActive && grabInteractable != null && (grabbable.IsHolding(rightHand) || grabbable.IsHolding(leftHand)))
        {
            UpdateTooltipPosition();
        }
    }


// POPULATE TEXT ONTO TOOLTIP CARD ***********************************************
public string buildTooltip()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        Image imageComponent = tooltip.GetComponentInChildren<Image>();
        TextMeshProUGUI textComponent = imageComponent.GetComponentInChildren<TextMeshProUGUI>();
        string tooltipTag = grabInteractable.tag;
        textComponent.text = $"{tooltipTag}";
        string textOnCard = textComponent.text;

        return textOnCard;
    }
// ********************************************************


    private void UpdateTooltipPosition()
    {
        if (tooltip != null)
        {
            Grabbable grabbable = GetComponent<Grabbable>();
            if (grabbable.IsHolding(rightHand))
            {
                // Set tooltip above hand
                Vector3 rightHandPosition = rightHand.transform.position;
                Vector3 tooltipPosition = rightHandPosition + Vector3.up * tooltipOffset;
                tooltip.transform.position = tooltipPosition;
            }
            else
            {
                Vector3 leftHandPosition = leftHand.transform.position;
                Vector3 tooltipPosition = leftHandPosition + Vector3.up * tooltipOffset;
                tooltip.transform.position = tooltipPosition;
            }
        }
    }



    private void OnEnable()
    {
        action.Enable();
    }


    private void OnDisable()
    {
        action.Disable();
    }


    private void Pressed(InputAction.CallbackContext context)
    {
        Grabbable grabbable = GetComponent<Grabbable>();
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null && (grabbable.IsHolding(rightHand) || grabbable.IsHolding(leftHand)))
        {   
            isTooltipActive = true;
            HelperTips helperTips = GetComponent<HelperTips>();
            GameObject tooltip = helperTips.tutorialTooltip;
            if(tooltip != null && tooltip.activeSelf)
            {
                helperTips.destroyTutorialTooltip();
            }
            else
            {
                Debug.Log("Tooltip null");
            }

            ActivateTooltip();
            if (sound != null)
            {
                sound.Play();
            } else {
                Debug.Log("Sound: NULL");
            }
        }
        else
        {
            Debug.Log("interactable empty");
        }
    }

    private void Released(InputAction.CallbackContext context)
    {
        DeactivateTooltip();
        isTooltipActive = false;
    }



    // Method to activate the tooltip
    private void ActivateTooltip()
    {
        buildTooltip();
        Grabbable grabbable = GetComponent<Grabbable>();
        tooltip.SetActive(true);
            if (grabbable.IsHolding(rightHand))
            {
                // Set tooltip above right hand
                Vector3 rightHandPosition = rightHand.transform.position;
                Vector3 tooltipPosition = rightHandPosition + Vector3.up * tooltipOffset;

                // Set tooltip to face the user
                Vector3 cameraToTooltip = tooltipPosition - Camera.main.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(cameraToTooltip, Vector3.up);
                tooltip.transform.rotation = lookRotation;

                // Convert world space position to screen space
                tooltip.transform.position = Camera.main.WorldToScreenPoint(tooltipPosition);
            }
            else
            {
                // Set tooltip above left hand
                Vector3 leftHandPosition = leftHand.transform.position;
                Vector3 tooltipPosition = leftHandPosition + Vector3.up * tooltipOffset;

                // Set tooltip to face the user
                Vector3 cameraToTooltip = tooltipPosition - Camera.main.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(cameraToTooltip, Vector3.up);
                tooltip.transform.rotation = lookRotation;

                // Convert world space position to screen space
                tooltip.transform.position = Camera.main.WorldToScreenPoint(tooltipPosition);
            }
    }

    // Method to deactivate the tooltip
    private void DeactivateTooltip()
    {
        if (tooltip != null)
        {
            tooltip.SetActive(false);
        }
    }

    // Event handler for when the object is grabbed
    private void OnSelectEnter(XRBaseInteractor interactor)
    {
        Debug.Log("object selected");
        ActivateTooltip();
    }

    // Event handler for when the object is released
    private void OnSelectExit(XRBaseInteractor interactor)
    {
        DeactivateTooltip();
    }
}
