using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIBehavior : MonoBehaviour // one of these days, all of the input stuff will go to an input manager.
{
    private int goldAmnt = 750;
    public BarManager barMannager;
    
    [SerializeField] List<Button> questButtons;
    [SerializeField] GameObject questPanel;
    [SerializeField] Text patronName;
    [SerializeField] Button[] controls;
    [SerializeField] GameObject openedQuestPanel;
    [SerializeField] Button backToSceneButton;
    [SerializeField] Button backToBoardButton;
    [SerializeField] Text GoldText;
    [SerializeField] Text descriptionText;


    [SerializeField]
    GameObject haggleField;
    [SerializeField]
    GameObject hagglePannel;
    [SerializeField]
    Button haggleButton;
    [SerializeField]
    Text haggleText;

    private Seat selectedPatron;
    private enum stateOfBar { NORMAL, HAGGLE, POSTING};
    private stateOfBar barState;

    private void Start()
    {
        setInputsToActive(false, 0, 0);
        TurnHaggleOn(false);
        barState = stateOfBar.NORMAL;
        GoldText.text = "Gold:" + goldAmnt;
        selectedPatron = null;
    }
    private void Update()
    {
        ScanForPatron();
    }

    public void OnClickQuestBoard()         //When you click UI Quest Board
    {
        if (barState != stateOfBar.POSTING)
        {
            questPanel.SetActive(true);
            barState = stateOfBar.POSTING;
        }
    }

    public void OnClickBackToSceneButton()  //Back button that closes quest board
    {
        if (barState == stateOfBar.POSTING)
        {
            questPanel.SetActive(false);
            
        }
        else if (barState == stateOfBar.HAGGLE)
        {
            TurnHaggleOn(false);
        }
        barState = stateOfBar.NORMAL;
    }

    /// /////////////////////////// Quest stuff/////////////////////////
  
    public void OnClickBackToBoardButton()  //Back button that closes individual quest
    {
        openedQuestPanel.SetActive(false);
        backToSceneButton.gameObject.SetActive(true);
    }

    public void OnClickQuest()
    {
        descriptionText.text = questButtons[0].GetComponent<Quest>().getQuestDescription();
        openedQuestPanel.SetActive(true);
        backToSceneButton.gameObject.SetActive(false);
    }

    public void OnClickQuest2()
    {
        descriptionText.text = questButtons[1].GetComponent<Quest>().getQuestDescription();
        openedQuestPanel.SetActive(true);
        backToSceneButton.gameObject.SetActive(false);
    }

    public void OnClickQuest3()
    {
        descriptionText.text = questButtons[2].GetComponent<Quest>().getQuestDescription();
        openedQuestPanel.SetActive(true);
        backToSceneButton.gameObject.SetActive(false);
    }

    public void OnClickQuest4()
    {
        descriptionText.text = questButtons[3].GetComponent<Quest>().getQuestDescription();
        openedQuestPanel.SetActive(true);
        backToSceneButton.gameObject.SetActive(false);
    }

    public void OnClickQuest5()
    {
        descriptionText.text = questButtons[4].GetComponent<Quest>().getQuestDescription();
        openedQuestPanel.SetActive(true);
        backToSceneButton.gameObject.SetActive(false);
    }


    public void ChangeTextBubble(string textToGoOut)
    {
        Debug.Log(textToGoOut);
    }



    /// /////////////// Scan Stuff /////////////////////////////////////

    private void ScanForPatron() // not too sure about this. 
    {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 5f;

            Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);

            Collider2D[] col = Physics2D.OverlapPointAll(v);

            if (col.Length > 0)
            {
                foreach (Collider2D c in col)
                {
                    displayName(c.GetComponent<Seat>().patron.SayName(), mousePosition.x, mousePosition.y);
                    selectedPatron = c.GetComponent<Seat>();
                }
                if (Input.GetMouseButtonDown(0))// Hack
                {
                    setInputsToActive(true, mousePosition.x, mousePosition.y);
                }
            }
            else
            {
                displayName(" ", 0, 0);
            }
    }

    public void displayName(string thePatronsName, float xPos, float yPos)
    {
        patronName.text = thePatronsName;
        patronName.transform.position = new Vector2(xPos, yPos);
    }


    /////////////////////////////////MenuStuff//////////////////////////

    public void setInputsToActive(bool onOff, float xPos, float yPos)
    {
        foreach (Button B in controls)
        {
            B.gameObject.SetActive(onOff);

        }
        controls[0].transform.position = new Vector3(xPos, yPos + 170, 0);
        controls[1].transform.position = new Vector3(xPos + 80, yPos + 100, 0);
        controls[2].transform.position = new Vector3(xPos - 80, yPos + 100, 0);
    }

    public void OnDrinkClick()
    {
        ChangeGold(true, 50);
        setInputsToActive(false, 0, 0);
        ChangeTextBubble(barMannager.thingToSay(DiologueLoader.responceType.DRINK, selectedPatron));
    }

    public void OnAdventureClick()
    {
        setInputsToActive(false, 0, 0);
        ChangeTextBubble(barMannager.thingToSay(DiologueLoader.responceType.ADVENTURE, selectedPatron));
    }

    public void OnTalkClick()
    {
        setInputsToActive(false, 0, 0);
        ChangeTextBubble(barMannager.thingToSay(DiologueLoader.responceType.TALK, selectedPatron));
    }


    /// ///////////////////////Haggle Stuff///////////////////////////////  I HAVE TO SOMEHOW GET THIS INTO HAGGLE MANAGER... FOR REASONS

    public void openHaggleUI(string missionName)
    {
        setInputsToActive(false, 0, 0);
        if (barState == stateOfBar.NORMAL)
        {
            TurnHaggleOn(true);
            haggleText.text = missionName;
            barState = stateOfBar.HAGGLE;

        }
    }


    private void TurnHaggleOn(bool onOff)
    {
        hagglePannel.SetActive(onOff);
        haggleButton.gameObject.SetActive(onOff);
        haggleField.gameObject.SetActive(onOff);
    }

    public void onHaggleButtonDown() //don't know If I should be doing this math here or somewhere else.
    {
        int suggestedPrice = Convert.ToInt16(haggleField.GetComponent<InputField>().text);
        if (suggestedPrice < goldAmnt)
        {
            if (suggestedPrice >= selectedPatron.patron.getGoldThreshold())
            {
                ChangeTextBubble(barMannager.thingToSay(DiologueLoader.responceType.ACCEPT, selectedPatron));
                TurnHaggleOn(false);
                ChangeGold(false, suggestedPrice);
                barMannager.clearASeat(selectedPatron);
                //Trigger somekind of rundown timer for the patron to leave... 
            }
            else
            {
                ChangeTextBubble(barMannager.thingToSay(DiologueLoader.responceType.DECLINE, selectedPatron));
            }
        }
        //else change thing to red or something... possible lie mechanic???
    }


    ////////Gold Stuff//////
    public void ChangeGold(bool isAdd, int ammount) // the bool is a little weird... I just need a good way to distinguish adding from subtracting
    {
        if (isAdd)
            goldAmnt += ammount;
        else if (!isAdd)
            goldAmnt -= ammount;


        GoldText.text = "Gold:" + goldAmnt;
    }
    

}
