using UnityEngine;
using System.Collections;

public class Patron : MonoBehaviour
{

    private string name;
    private string[] dialogues;
    private int goldThreshold;

    public string Talk(int selectedDio)
    {
        return dialogues[selectedDio];
    }

    public string SayName()
    {
        return name;
    }
}
