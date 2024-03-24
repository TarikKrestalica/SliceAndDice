using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] protected float healthValue;
    [SerializeField] GameObject teleport;

    public float GetHealthValue()
    {
        return healthValue;
    }

    public void SetUpSliderValues()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        progressBar progressBar = this.transform.GetChild(0).GetChild(0).GetComponent<progressBar>();
        if (!progressBar)
        {
            Debug.LogError("No progress bar found!");
            return;
        }

        progressBar.SetUpTheSlider();
    }

    public GameObject GetTeleportationPoint()
    {
        return teleport;
    }
}

