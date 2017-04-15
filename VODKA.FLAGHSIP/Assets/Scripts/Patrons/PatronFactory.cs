using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class PatronFactory  {
    // Add a patron pallet to each patron, have this shuffle each time so that two of the same are not drawn in a row.
    // players may have a description later This will be randomized so not two have the same, even if there are 99 warriros. 
    // same with endings for each lvl 6 folk hero. 
    private static PatronFactory instance = null;
    private List<string> names = new List<string>();
    private List<string> lastNames = new List<string>();
    private static readonly object padloc = new object();

    public static PatronFactory Instance
    {
        get
        {
            lock (padloc)
            {
              
                if (instance == null)
                {
                    instance = new PatronFactory();
                }
                return instance;
            }
        }
    }

    public void loadTools()
    {
        XmlDocument allVisitors = new XmlDocument();
        allVisitors.Load("PatronAssemblyParts.xml");
        foreach (XmlNode node in allVisitors.SelectSingleNode("root/FirstNames"))
        { 
         instance.names.Add(node.InnerText);
        }
        foreach (XmlNode node in allVisitors.SelectSingleNode("root/LastNames"))
        {
            instance.lastNames.Add(node.InnerText);
        }
    }


    public Patron CreateNewPatron()
    {
        Patron guest = new Patron(createName(), 0, assignClass(), assignRace());
        return guest; 
    }

   private string createName()
    {
        string nameToReturn = names[RollFor(0, names.Count -1)];
        nameToReturn += " " +lastNames[RollFor(0, lastNames.Count - 1)];
        return nameToReturn;
    }

    private Patron.type assignClass()
    {
        Patron.type disciplineToReturn = (Patron.type)RollFor(0, (int)Patron.type.BARD);
        return disciplineToReturn;
    }

    private Patron.race assignRace()
    {
        Patron.race raceToReturn = (Patron.race)RollFor(0, (int)Patron.race.ELF);
        return raceToReturn;
    }

    private int RollFor( int min,int max)
    {
        return Random.Range(min, max + 1);
    }
}
