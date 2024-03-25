using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public ItemProbabilityDistributor itemProbabilityDistributor;

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

    public static Goblin goblin
    {
        get
        {
            if (gameManager.m_goblin == null)
            {
                gameManager.m_goblin = GameObject.FindGameObjectWithTag("Goblin").GetComponent<Goblin>();
            }

            return gameManager.m_goblin;
        }
    }

    private Goblin m_goblin;

    public static BehaviorManager behaviorManager
    {
        get
        {
            if (gameManager.m_behaviorManager == null)
            {
                gameManager.m_behaviorManager = GameObject.FindGameObjectWithTag("Goblin").GetComponent<BehaviorManager>();
            }

            return gameManager.m_behaviorManager;
        }
    }

    private BehaviorManager m_behaviorManager;

    private void Awake()
    {
        if(gameManager != null)
        {
            Destroy(gameManager);
        }

        gameManager = this;
        DontDestroyOnLoad(gameManager);
        itemProbabilityDistributor = GetComponent<ItemProbabilityDistributor>();
        if (!itemProbabilityDistributor)
        {
            Debug.LogError("Randomization between items can't happen. Please try again!");
            return;
        }

        itemProbabilityDistributor.enabled = false;
    }


    private void Update()
    {
        if (!itemProbabilityDistributor.enabled)
            return;

        if (itemProbabilityDistributor.IsComplete())
        {
            player.GetCurrentObstacle().SetUpSliderValues();
            itemProbabilityDistributor.enabled = false;
        }
    }
}
