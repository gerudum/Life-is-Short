using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Logic
{
    public override void Activate()
    {

        if (toggled == false)
        {
            trigger.SetActive(!trigger.activeSelf);
            toggled = true;
        } else if (toggled == true)
        {
            trigger.SetActive(!trigger.activeSelf);
            toggled = false;
        }

        base.Activate();
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
       // base.OnTriggerExit2D(collision);
    }
}
