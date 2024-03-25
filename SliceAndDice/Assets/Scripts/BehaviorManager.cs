using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorManager : MonoBehaviour
{
    private static bool isComplaint = false;
    private static bool isCompliment = false;

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

    public static bool IsCompliment()
    {
        return isCompliment;
    }

    public static bool IsComplaint()
    {
        return isComplaint;
    }
}
