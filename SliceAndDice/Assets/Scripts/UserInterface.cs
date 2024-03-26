using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public GameObject leaderBoardUI;
    public GameObject timerUI;
    public RectTransform leaderBoardImage;
    public RectTransform canvas;
    void Start()
    {
        leaderBoardUI.SetActive(false);
        timerUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        leaderBoardImage.sizeDelta = canvas.sizeDelta;
    }
}
