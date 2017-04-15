using UnityEngine;
using System.Collections;

public class Patron : MonoBehaviour
{
    public enum type { WARRIOR =0, ROUGE, WIZARD, BARD };
    public enum race { HUMAN, DWARF, ELF};
    private string name;
    private byte level; 
    public type disciplineType { get;  set; }
    public race patronsRace { get; set; }
    private bool hasInformation = false;

    //private string[] dialogues;
    private int goldThreshold;

    public Patron(string newName,byte newLevel, type newType, race newRace )
    {
        name = newName;
        level = newLevel;
        disciplineType = newType;
        patronsRace = newRace;
    }

    //public string Talk(int selectedDio)
    //{
    //    return dialogues[selectedDio];
    //}

    //public void SetTalk(string somethingWittyToSay)
    //{
    //    dialogues[0] = somethingWittyToSay;
    //}

    public string SayName()
    {
        return name;
    }

    public byte sayLevel()
    {
        return level;
    }

    public race sayRace()
    {
        return patronsRace;
    }

    public type sayClass()
    {
        return disciplineType;
    }
    
    public void setHasInformation(bool informed)
    {
        hasInformation = informed;
    }

    public bool giveHasInformation()
    {
        return hasInformation; 
    }

    public void changeThreshold(int moneyNeeded)
    {
        goldThreshold = moneyNeeded;
    }

    public int getGoldThreshold()
    {
        return goldThreshold;
    }
}
