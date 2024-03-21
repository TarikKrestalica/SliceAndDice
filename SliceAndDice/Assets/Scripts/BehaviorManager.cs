using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorManager : MonoBehaviour
{
    private int compliments = 0;
    private int complaints = 0;

    public void AddCompliment()
    {
        compliments += 1;
    }

    public void AddComplaint()
    {
        complaints += 1;
    }

    public int GetNumberOfCompliments()
    {
        return compliments;
    }

    public int GetNumberOfComplaints()
    {
        return complaints;
    }
}
