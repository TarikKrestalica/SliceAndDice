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
    public int probability;
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
    [SerializeField] private Item itemChosen;

    [Header("Display")]
    public ItemDisplay itemDisplay;
    [SerializeField] Button stopButton;

    [Header("Time delay between items")]
    [Range(0, 4f)]
    [SerializeField] float timeDelay;

    bool isRunning;

    private System.Random rnd = new System.Random();
    int currentProbability = 50;
    int selectedProbability = 50;


    IEnumerator ShuffleItems()
    {
        currentProbability = FindMaxProbability();
        WaitForSeconds wait = new WaitForSeconds(timeDelay);
        int i = 0;
        while (isRunning)
        {
            yield return wait;
            itemDisplay.textBox.text = items[i].name;
            selectedProbability = rnd.Next(0, currentProbability + 1);
            if (items[i].probability > 0 && items[i].probability >= selectedProbability)
            {
                itemChosen = items[i];
            }

            i++;
            i = i % items.Count;
        }

        if(itemChosen.name != itemDisplay.textBox.text)
        {
            itemChosen = FindItem(itemDisplay.textBox.text);
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

    int FindMaxProbability()
    {
        int max = 0;
        for(int i = 0; i < items.Count; i++)
        {
            if(max <= items[i].probability)
            {
                max = items[i].probability;
            }
        }

        return max;
    }

    Item FindItem(string name)
    {
        Item returned = null;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == name)
                returned = items[i];
        }

        return returned;
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


