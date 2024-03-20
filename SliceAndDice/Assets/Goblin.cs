using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Goblin : MonoBehaviour
{
    private RawImage m_rawImage;
    [SerializeField] private Texture nonHoveredSprite;
    [SerializeField] private Texture hoveredSprite;

    private void Awake()
    {
        m_rawImage = GetComponent<RawImage>();
        if (!m_rawImage)
        {
            Debug.LogError("Raw Image is not attached. Please attach it for best result!");
            return;
        }

        m_rawImage.texture = nonHoveredSprite;
    }

    // Event Trigger
    public void SwitchToNonHover(BaseEventData data)
    {
        m_rawImage.texture = nonHoveredSprite;
    }

    // Non-event trigger
    public void SwitchToNonHover()
    {
        m_rawImage.texture = nonHoveredSprite;
    }

    // Event Trigger
    public void SwitchToHover(BaseEventData data)
    {
        m_rawImage.texture = hoveredSprite;
    }

    // Non-event trigger
    public void SwitchToHover()
    {
        m_rawImage.texture = hoveredSprite;
    }

}
