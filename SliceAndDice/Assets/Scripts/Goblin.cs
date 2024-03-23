using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoblinGreen : MonoBehaviour
{
    private RawImage rawImage;
    [SerializeField] private Texture nonHoverableSprite;
    [SerializeField] private Texture hoverableSprite;

    private void Start()
    {
        rawImage = GetComponent<RawImage>();
        if (!rawImage)
        {
            Debug.LogError("Raw Image is not attached. Please attach it for best result!");
            return;
        }

        rawImage.texture = nonHoverableSprite;
    }



    // Event Trigger
    public void SwitchToNonHovered(BaseEventData data)
    {
        rawImage.texture = nonHoverableSprite;
    }

    // Non-event trigger
    public void SwitchToNonHovered()
    {
        rawImage.texture = nonHoverableSprite;
    }

    // Event Trigger
    public void SwitchToHovered(BaseEventData data)
    {
        rawImage.texture = hoverableSprite;
    }

    // Non-event trigger
    public void SwitchToHovered()
    {
        rawImage.texture = hoverableSprite;
    }

    public void SetIconActive(bool toggle)
    {
        rawImage.enabled = toggle;
    }
}
