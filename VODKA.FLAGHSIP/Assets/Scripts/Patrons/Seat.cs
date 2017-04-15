using UnityEngine;
using System.Collections;

public class Seat : MonoBehaviour { // ArmSTRONG family style programming

    public ApperanceManager aM;
    public Patron patron;
    // Use this for initialization
    void Start () {
        
	}
	
   public void patronTakesASeat(Patron seatedPatron)
    {
        patron = seatedPatron;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = aM.HowTheyLook(patron.sayClass());
    }
}
