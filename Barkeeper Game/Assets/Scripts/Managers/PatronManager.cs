using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PatronManager : MonoBehaviour
{
    [SerializeField] Text patronText;
    [SerializeField] Text goldText;
    [SerializeField] Button haggleButton;
    [SerializeField] InputField haggleField;

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;
    private float startTime;
    public SpriteRenderer patronSprite;


    bool buttonPressed = false;
    int goldValue = 3000;
    int haggleValue;
    int? tempHaggleValue = null;

    void Start ()
    {
        //patronSprite.color = new Color(1f, 1f, 1f, 0f);
        haggleField.gameObject.SetActive(false);
        haggleButton.gameObject.SetActive(false);
        goldText.text = "GOLD: " + goldValue + "g";
        StartCoroutine(TalkToPatron());
        
    }
	
	public void HaggleButtonPressed ()
    {
        int testValue;
        if (int.TryParse(haggleField.text, out testValue))
        {
            tempHaggleValue = testValue;
        }

        if (tempHaggleValue > 1000 && tempHaggleValue < goldValue)
        {
            StartCoroutine(GoodAmountYes());
        }
        else if (tempHaggleValue > goldValue)
        {
            StartCoroutine(BadAmountNo());
        }
        else if (tempHaggleValue < 1000)
        {
            StartCoroutine(TooPoorStop());
        }
    }

    IEnumerator TalkToPatron()
    {
        patronText.text = "Patron: Hey, bartender, couldn't help but notice you needed someone to slay a dragon.";
        yield return new WaitForSeconds(5);
        patronText.text = "Patron: For the right price, I'd be willing to take that quest off your hands.";
        yield return new WaitForSeconds(5);
        haggleField.gameObject.SetActive(true);
        haggleButton.gameObject.SetActive(true);

    }

    IEnumerator GoodAmountYes()
    {
        haggleField.gameObject.SetActive(false);
        haggleButton.gameObject.SetActive(false);
        haggleValue = tempHaggleValue ?? default(int);
        goldValue -= haggleValue;
        patronText.text = "Patron: " + tempHaggleValue + " gold, eh? Sounds fair!";
        yield return new WaitForSeconds(5);
        goldText.text = "GOLD: " + goldValue + "g";
        patronText.text = "Patron: Thanks for the coin, I'll be off then!";
    }

    IEnumerator BadAmountNo()
    {
        buttonPressed = false;
        haggleField.gameObject.SetActive(false);
        haggleButton.gameObject.SetActive(false);
        patronText.text = "Patron: You don't have enough coin to pay me that!";
        yield return new WaitForSeconds(5);
        patronText.text = "Patron: Try another offer, a little lower this time.";
        haggleField.gameObject.SetActive(true);
        haggleButton.gameObject.SetActive(true);
    }

    IEnumerator TooPoorStop()
    {
        buttonPressed = false;
        haggleField.gameObject.SetActive(false);
        haggleButton.gameObject.SetActive(false);
        haggleField.text = "";
        patronText.text = "Patron: You can't expect me to go on a job like this for that cheap!";
        yield return new WaitForSeconds(5);
        patronText.text = "Patron: Try another offer, a little higher this time.";
        haggleField.gameObject.SetActive(true);
        haggleButton.gameObject.SetActive(true);
    }

}
