using UnityEngine;
using System.Collections;

public class QuestFactory : MonoBehaviour {

    [SerializeField] Quest q;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private string[] questGivers = { "Yuri", "Grover", "Drew", "Eli", "Ryan" };
    private string[] questNames = { "Save the Sheep", "Slay the Dragon", "Steal a Precious Heirloom", "Solve the Sphinx's Riddles", "Save Delfino Plaza" };
    private string[] questDescriptions = { "Save My Sheep", "Slay a Dragon", "Steal a Precious Heirloom", "Solve the Sphinx's Riddles", "Save Delfino Plaza" };

    public Quest questCreator(int questParts)
    {
        //string readableQuest = questNames[questParts] + "\n\n" + questGivers[questParts] + " wants you to " + questDescriptions[questParts] + ".";
        //return readableQuest;   ARCHIVED 
        q.assignQuestGiver(questGivers[questParts]);
        q.assignQuestName(questNames[questParts]);
        q.assignQuestDescript(questDescriptions[questParts]);

        return q;
    }


}
