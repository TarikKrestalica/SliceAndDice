using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Item
{
    public string name;
    [Range(0, 100f)]
    public float probability;
}

[System.Serializable]
public class ItemDisplay
{
    public Image panel;
    public TMP_Text textBox;
}

public class ItemProbabilityDistributor : MonoBehaviour
{
    [SerializeField] List<Item> items;

    [Header("Display")]
    public ItemDisplay itemDisplay;
    [SerializeField] Button stopButton;

    [Header("Time delay between items")]
    [Range(0, 4f)]
    [SerializeField] float timeDelay;

    bool isRunning;

    IEnumerator ShuffleItems()
    {
        WaitForSeconds wait = new WaitForSeconds(timeDelay);
        while (isRunning)
        {
            for (int i = 0; i < items.Count; i++)
            {
                itemDisplay.textBox.text = items[i].name;
                yield return wait;
            }
        }

        StopAllCoroutines();
    }

    public void SetShuffleState(bool toggle)
    {
        isRunning = toggle;
        if (toggle)
            stopButton.gameObject.SetActive(true);
        else
            stopButton.gameObject.SetActive(false);
    }

    public bool IsComplete()
    {
        return !isRunning;
    }

    public void StartSelection()
    {
        itemDisplay.panel.gameObject.SetActive(true);
        SetShuffleState(true);
        StartCoroutine(ShuffleItems());
    }
}


