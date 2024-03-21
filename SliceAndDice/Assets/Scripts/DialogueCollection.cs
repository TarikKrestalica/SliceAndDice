using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollection : MonoBehaviour
{
    [SerializeField] List<Dialogue> randomDialogues;
    private System.Random rnd = new System.Random();

    public void ChooseRandomDialogue()
    {
        int randIndex = rnd.Next(0, randomDialogues.Count);
        GetComponent<DialogueTrigger>().dialogue = randomDialogues[randIndex];
    }
}
