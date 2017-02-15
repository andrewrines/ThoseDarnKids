using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIBehavior : MonoBehaviour
{

    [SerializeField] List<Button> questButtons;
    [SerializeField] GameObject questPanel;
    [SerializeField] GameObject openedQuestPanel;
    [SerializeField] Button backToSceneButton;
    [SerializeField] Button backToBoardButton;
    [SerializeField] Text descriptionText;


    private bool questPanelIsActive;

    public void OnClickQuestBoard()         //When you click UI Quest Board
    {
        if (questPanelIsActive == false)
        {
            questPanel.SetActive(true);
            questPanelIsActive = true;
        }
    }

    public void OnClickBackToSceneButton()  //Back button that closes quest board
    {
        if (questPanelIsActive == true)
        {
            questPanel.SetActive(false);
            questPanelIsActive = false;
        }
    }

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


}
