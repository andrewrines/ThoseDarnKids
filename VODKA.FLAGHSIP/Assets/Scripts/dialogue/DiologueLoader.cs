using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class DiologueLoader  { // ill try to make this not a monobehavior, but for testing purposes. 
    public enum responceType { GREET, TALK, ADVENTURE, DECLINE, DRINK, ACCEPT, RUMOR, EXIT};
    Dictionary<responceType, List<string>> responce;
    List<string> GreetDio;
    List<string> TalkDio;
    List<string> AdventureDio;
    List<string> DeclineDio;
    List<string> DrinkDio;
    List<string> AcceptDio;
    List<string> ExitDio; // no exit dio yet. 
    List<string> RumorDio;
    // Use this for initialization
    public void init () {
        responce = new Dictionary<responceType, List<string>>();
        GreetDio = new List<string>();
        TalkDio = new List<string>();
        AdventureDio = new List<string>();
        DeclineDio = new List<string>();
        DrinkDio = new List<string>();
        AcceptDio = new List<string>();
        ExitDio = new List<string>();
        RumorDio = new List<string>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void loadDiologue() // This will serve as our database for all diolouges.... It might be bad though will upgrade as I learn.
    {
        XmlDocument allVisitors = new XmlDocument();
        allVisitors.Load("dialogue.xml");
        foreach (XmlNode node in allVisitors.SelectSingleNode("Dialogues/Hellos"))
        {
            GreetDio.Add(node.InnerText);
        }
        responce.Add(responceType.GREET, GreetDio);

        foreach (XmlNode node in allVisitors.SelectSingleNode("Dialogues/Quest"))
        {
            RumorDio.Add(node.InnerText);
        }
        responce.Add(responceType.RUMOR, RumorDio);

        foreach (XmlNode node in allVisitors.SelectSingleNode("Dialogues/Drink"))
        {
            DrinkDio.Add(node.InnerText);
        }
        responce.Add(responceType.DRINK, DrinkDio);

        foreach (XmlNode node in allVisitors.SelectSingleNode("Dialogues/GoOnQuest"))
        {
            AdventureDio.Add(node.InnerText);
        }
        responce.Add(responceType.ADVENTURE, AdventureDio);

        foreach (XmlNode node in allVisitors.SelectSingleNode("Dialogues/Accept"))
        {
            AcceptDio.Add(node.InnerText);
        }
        responce.Add(responceType.ACCEPT, AcceptDio);

        foreach (XmlNode node in allVisitors.SelectSingleNode("Dialogues/Decline"))
        {
            DeclineDio.Add(node.InnerText);
        }
        responce.Add(responceType.DECLINE, DeclineDio);

        foreach (XmlNode node in allVisitors.SelectSingleNode("Dialogues/Talk"))
        {
            TalkDio.Add(node.InnerText);
        }
        responce.Add(responceType.TALK, TalkDio);

       
    }

    public string lookUp(responceType typeOfResponce, Patron.type AdventureClass)
    {
        List<string> test;
        responce.TryGetValue(typeOfResponce, out test);
        return test[(int)AdventureClass];
    }

}
