using UnityEngine;
using System.Collections;

public class ApperanceManager : MonoBehaviour
{

    public Sprite[] allInGameApperances;


    public Sprite HowTheyLook(Patron.type typeIn)
    {
        switch (typeIn)
        {
            case Patron.type.BARD:
                {
                    return allInGameApperances[0];
                }
            case Patron.type.ROUGE:
                return allInGameApperances[1];
            case Patron.type.WARRIOR:
                return allInGameApperances[2];
            case Patron.type.WIZARD:
                return allInGameApperances[3];

            default:
                {
                    Debug.Log("Error");
                    return null;

                }

        }
    }
}
