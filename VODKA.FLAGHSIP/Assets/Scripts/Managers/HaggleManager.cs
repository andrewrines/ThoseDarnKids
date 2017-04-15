using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HaggleManager : MonoBehaviour {

    [SerializeField]
    UIBehavior uiManager; // HACK
   

    private void Start()
    {
        
    }


    public void openDebateMenu(Quest incomingQuest, Patron personGoingOnQuest) 
    {
        determineHagglePrice(incomingQuest,personGoingOnQuest);
        uiManager.openHaggleUI(incomingQuest.getQuestName() + " \n" + incomingQuest.getQuestDescription());
    }

    private void determineHagglePrice(Quest incomingQuest,Patron personGoingOnQuest)// helper function for math
    {
        int price = RollFor(500, 1000);  //TODO, give each quest a level 0-6;after i get this working. 
        price += (RollFor(0, 200) * personGoingOnQuest.sayLevel());
        // fun Ideas for Bards and theives charging more.
        personGoingOnQuest.changeThreshold(price); 
    }

    private int RollFor(int min, int max) // should throw this in a util... DREAMS
    {
        return Random.Range(min, max + 1);
    }

  
}
