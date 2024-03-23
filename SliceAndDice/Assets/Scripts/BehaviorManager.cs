using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorManager : MonoBehaviour
{
    private bool isComplaint = false;
    private bool isCompliment = false;

    public void AddCompliment()
    {
        isComplaint = false;
        isCompliment = true;
    }

    public void AddComplaint()
    {
        isComplaint = true;
        isCompliment = false;
    }
}
