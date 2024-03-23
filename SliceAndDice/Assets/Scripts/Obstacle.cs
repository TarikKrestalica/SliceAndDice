using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float healthValue;
    [Range(200f, 2000f)]
    [SerializeField] float fillSpeed;

    public float GetHealthValue()
    {
        return healthValue;
    }

    public float GetFillSpeed()
    {
        return fillSpeed;
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
}

