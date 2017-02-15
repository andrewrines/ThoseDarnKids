using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{

    private Quest[] quests = new Quest[5];  
    [SerializeField] Button[] questButtons = new Button[5];
    [SerializeField] List<Text> questTexts;
    [SerializeField] Text descriptionText;
    [SerializeField] QuestFactory qf;
    [SerializeField] Transform parent;

   

	void Start ()
    {
        qf = GetComponent<QuestFactory>();
        PostToBoard();
    }

    private void PostToBoard()
    {
        parent = transform;
        Debug.Log(qf);
        for (int i = 0; i < 5; i++)
        {
            Quest Temp = qf.questCreator(i);  // any way to directly pass Quest to each of the buttons? I attempted factory pattern.
            Quest Temp2 = questButtons[i].GetComponent<Quest>();
            Temp2.assignQuestName(Temp.getQuestName());
            Temp2.assignQuestGiver(Temp.getQuestGiver());
            Temp2.assignQuestDescript(Temp.getQuestDescription());
            questButtons[i].GetComponentInChildren<Text>().text = Temp2.getQuestName();
            

            //questButtons[i].gameObject.AddComponent<Quest>() = 
            //Quest temp = questButtons[i].GetComponent<Quest>();
            //temp = qf.questCreator(i);
            //Debug.Log(questButtons[i].GetComponent<Quest>().getQuestName());
            //quests[i] = qf.questCreator(i);  //
            //questButtons[i].GetComponentInChildren<Text>().text = quests[i].getQuestName();
            //questTexts.Add(descriptionText);
        }
    }

    public void findButtonClicked()
    {
        Debug.Log("");
    }
    void Update ()
    {
	
	}
}
