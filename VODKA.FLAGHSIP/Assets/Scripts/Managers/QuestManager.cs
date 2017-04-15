using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{

    private Quest[] questsOnBoard = new Quest[5];
    private int numberOfQuestsOnBoard;
    [SerializeField] Button[] questButtons = new Button[5];
    [SerializeField] List<Text> questList;
    [SerializeField] Text descriptionText;
    [SerializeField] QuestFactory qf;
    [SerializeField] Transform parent;

   

	void Start ()
    {
        qf = GetComponent<QuestFactory>();
        numberOfQuestsOnBoard = 0;
        //PostToBoard();
    }

    public void PostToBoard()  // Ill need to clean this up onece I get it working.
    {
        parent = transform;
        Quest Temp = qf.questCreator();  // any way to directly pass Quest to each of the buttons? I attempted factory pattern.
        Quest Temp2 = questButtons[numberOfQuestsOnBoard].GetComponent<Quest>();
        Temp2.assignQuestName(Temp.getQuestName());
        Temp2.assignQuestGiver(Temp.getQuestGiver());
        Temp2.assignQuestDescript(Temp.getQuestDescription());
        questButtons[numberOfQuestsOnBoard].GetComponentInChildren<Text>().text = Temp2.getQuestName();
        questsOnBoard[numberOfQuestsOnBoard] = questButtons[numberOfQuestsOnBoard].GetComponent<Quest>();
        numberOfQuestsOnBoard++; 
    }

    public Quest chooseAQuestFromBoard()
    {
        Debug.Log(getNumberofQuests());
        int questToRemove = Random.Range(0, getNumberofQuests() -1);
        return questsOnBoard[questToRemove];
    }

   public int getNumberofQuests()
    {
        return numberOfQuestsOnBoard;
    }
   
}
