using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class QuestFactory : MonoBehaviour {
    private XmlDocument allQuests;
   
    private int numberOfQuestsInGame;
	// Use this for initialization
	void Start () {
        
    }

    private int countQuests()
    {
        int temp = 0;
        foreach (XmlNode node in allQuests.DocumentElement)
        {
            temp++;
        }
        return temp; 
    }
    public Quest questCreator()
    {
        Quest questToBuild = new Quest();
        allQuests = new XmlDocument(); // this was a test... this was only a test... 
        allQuests.Load("QuestElements.xml"); // need to find a new place for this, I am a student and I am learning something new
        numberOfQuestsInGame = countQuests();
        var questDoc = allQuests.DocumentElement.ChildNodes[rollFor(0,numberOfQuestsInGame)];
        questToBuild.assignQuestName(questDoc.ChildNodes[0].InnerText);
        questToBuild.assignQuestDescript(questDoc.ChildNodes[1].InnerText);
        return questToBuild;
    }

    private int rollFor(int min , int max)
    {
        return Random.Range(min, max);
    }

}
