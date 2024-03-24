using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotteryMachine : Obstacle
{
    // Fill Speed
    // Health and duration
    private System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        healthValue = rnd.Next(100, 400);
    }
}
