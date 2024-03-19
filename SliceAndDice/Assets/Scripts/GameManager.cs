using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public static LotteryMachine lotteryMachine
    {
        get
        {
            if(gameManager.m_lotteryMachine == null)
            {
                gameManager.m_lotteryMachine = GameObject.FindGameObjectWithTag("LotteryMachine").GetComponent<LotteryMachine>();
            }

            return gameManager.m_lotteryMachine;
        }
    }

    private LotteryMachine m_lotteryMachine;

    public static PlayerController player
    {
        get
        {
            if (gameManager.m_player == null)
            {
                gameManager.m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            }

            return gameManager.m_player;
        }
    }

    private PlayerController m_player;

    private void Awake()
    {
        if(gameManager != null)
        {
            Destroy(gameManager);
        }

        gameManager = this;
        DontDestroyOnLoad(gameManager);
    }

}
