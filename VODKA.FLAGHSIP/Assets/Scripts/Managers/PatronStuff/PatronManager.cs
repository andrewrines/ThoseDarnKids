using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PatronManager : MonoBehaviour
{
    [SerializeField] Text patronText;
    [SerializeField] Text goldText;
    [SerializeField] Button haggleButton;
    [SerializeField] InputField haggleField;

    //public float minimum = 0.0f;
    //public float maximum = 1f;
    //public float duration = 5.0f;
    //private float startTime;
    private List<Patron> regulars = new List<Patron>();
    private Color tempColor;
    private AudioSource coinSound;
    [SerializeField] GameObject questToDelete;

    public void loadStarterPack()
    {
        PatronFactory.Instance.loadTools(); // NC Kicks stuff off by pulling things out of patorn assembly parts and putting it into a list of names
        for (int i = 0; i < 10; i++)
        {
            regulars.Add(PatronFactory.Instance.CreateNewPatron());
        }
    }

    public Patron drawPatronFromRegulars()
    {
        if (regulars.Count != 0)
        {
            int patronIndexer = RollFor(0, regulars.Count);
            Patron patronToReturn = regulars[patronIndexer];
            regulars.Remove(regulars[patronIndexer]);
            return patronToReturn;
        }
        else
            return PatronFactory.Instance.CreateNewPatron();
    }

    public void killPatron()
    {
        // Removes patron, for permanents , unless undead.
    }

    public Patron createNewCommonPatron()
    {
        return PatronFactory.Instance.CreateNewPatron();
    }

    public void addToRegulars(Patron patronToAdd)
    {
        //used when a patron returns from a mission, there bound to be back for more. 
        regulars.Add(patronToAdd);
    }

    public bool rollForHasInformation(int level) // I bet I can do some fun things, like bards get more percentile or something... Im having fun
    {                                           //ooo also! beer increases percent... yes! but their will be a blow out of total drunkeness if over a certain threshold. 
        int percentRoll = RollFor(0, 100);
        
            if (percentRoll >= 80 - (level * 15))
            {
            Debug.Log("HIT");
                return true;
            }
        return false; 
    }

    private int RollFor(int min, int max)
    {
        return Random.Range(min, max);
    }
}
       