using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Item
{
    public string classifier;
    public string name;
    [Range(0, 100f)]
    public float probability;
    public float fillSpeed;
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
    private Item itemChosen;

    [Header("Display")]
    public ItemDisplay itemDisplay;
    [SerializeField] Button stopButton;

    [Header("Time delay between items")]
    [Range(0, 4f)]
    [SerializeField] float timeDelay;

    bool isRunning;

    private System.Random rnd = new System.Random();

    IEnumerator ShuffleItems()
    {
        WaitForSeconds wait = new WaitForSeconds(timeDelay);
        int i = 0;
        while (isRunning)
        {
            yield return wait;
            itemDisplay.textBox.text = items[i].name;
            itemChosen = items[i];
            i++;
            i = i % items.Count;
        }

        StopAllCoroutines();
    }

    IEnumerator SetProbabilities()
    {
        string targetClassifier = "";
        if (BehaviorManager.IsCompliment())
            targetClassifier = "Compliment";
        else
            targetClassifier = "Complaint";

        int i = 0;
        while(i < items.Count)
        {
            if (items[i].classifier == targetClassifier)
            {
                items[i].probability += 10;
                if (items[i].probability >= 100)
                    items[i].probability = 100;
            }
            else
            {
                items[i].probability -= 10;
                if (items[i].probability <= 0)
                    items[i].probability = 0;
            }

            i++;

            yield return null;
        }
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
        StartCoroutine(SetProbabilities());
        StartCoroutine(ShuffleItems());
    }

    public Item GetSelectedItem()
    {
        return itemChosen;
    }
}


