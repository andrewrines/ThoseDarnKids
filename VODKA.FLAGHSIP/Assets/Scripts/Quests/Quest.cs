using UnityEngine;
using System.Collections;


public class Quest : MonoBehaviour
{
    private string questGiver;
    private string questName;
    private string questDescription;
   

   public void assignQuestGiver(string giverIn)
    {
        questGiver = giverIn;
    }

    public void assignQuestName (string questIn)
    {
        questName = questIn;
    }

    public void assignQuestDescript(string discriptIn)
    {
        questDescription = discriptIn;
    }

    public string getQuestName()
    {
        return questName;
    }

    public string getQuestGiver()
    {
        return questGiver;
    }

    public string getQuestDescription()
    {
        return questDescription;
    }
}
