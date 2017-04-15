using UnityEngine;
using System.Collections;

public class BarManager : MonoBehaviour {

    public PatronManager Pmanager;
    public QuestManager Qmanager;
    public DiologueLoader Dman;
    public HaggleManager Hmanager;
    public Seat[] Seats = new Seat[3];
    private Patron[] patronAtBar = new Patron[3];


    // Use this for initialization
    void Start () {
        
        Dman = new DiologueLoader();
        Pmanager.loadStarterPack();
        Dman.init();
        Dman.loadDiologue();
        Turn();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void StartDay()
    {
        // Throw in a command processor to process what the player wants to do,
        // The player can, talk to Jim,
        // Put up quests
        // order more ingreedents 
        // Shop for better loot
        // Start the day
    }

    public void Turn()
    {

        // A turn, here the patron manager will draw 3 patrons from the regulars deck
        for ( int i = 0; i < patronAtBar.Length ; i++)
        {
            if (patronAtBar[i] == null)
            {
                patronAtBar[i] = Pmanager.drawPatronFromRegulars();
                patronAtBar[i].setHasInformation(Pmanager.rollForHasInformation(patronAtBar[i].sayLevel())); //does our seated patron know anything? // may need to move to patron manager or factory.
                Seats[i].patronTakesASeat(patronAtBar[i]);
            }
            
        }


        // The player can talk to one of the three patrons, who will offer a greeting based on race and class ( possibly)
        // The player can offer them a drink
        // get information
        // talk ( so they can go on a quest) 
        // or ask roudy patrons to go away
        // patrons will persist from turn to turn.
        // after all patrons have been served ( or the player chooses) the turn will end and a new turn will start
        // there are 3 turns in a day, noon, afternoon and night. 
        // possibly have an after close function that will handle a score of the day's activities. 
    }

    public string thingToSay(DiologueLoader.responceType responce, Seat selectedSeat)
    {
        if (responce == DiologueLoader.responceType.TALK)
        {
            if (selectedSeat.patron.giveHasInformation() == true)
            {
                selectedSeat.patron.setHasInformation(false);
                Qmanager.PostToBoard(); // placeHolder, this will be put in a list of possible quests at some point once I get start of day working.
                return Dman.lookUp(DiologueLoader.responceType.RUMOR, selectedSeat.patron.sayClass());
            }
        }
        if (responce == DiologueLoader.responceType.ADVENTURE && Qmanager.getNumberofQuests() != 0)
        {
            Hmanager.openDebateMenu(Qmanager.chooseAQuestFromBoard(),selectedSeat.patron);
        }
        return Dman.lookUp(responce, selectedSeat.patron.sayClass());
    }

    public void clearASeat(Seat seatToClear)
    {
        int i = 0;
        // places adventurer on quest
        foreach (Seat s in Seats)
        {
            if (s == seatToClear)
            {
                patronAtBar[i] = null;
                Seats[i].GetComponent<SpriteRenderer>().sprite = null; 
                Seats[i].patron = null;
                //patronAtBar[i] = Pmanager.drawPatronFromRegulars();
                //patronAtBar[i].setHasInformation(Pmanager.rollForHasInformation(patronAtBar[i].sayLevel()));
                //Seats[i].patronTakesASeat(patronAtBar[i]);
            }
            i++;
        }
        //set a rundown timer
        //draws a new patron for seat
    }
}

