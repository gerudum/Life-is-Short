using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Logic
{
    public override void Activate()
    {

        if (!toggled)
        {
            trigger.SetActive(false);
            toggled = true;
        }
        if (toggled)
        {
            trigger.SetActive(true);
            toggled = false;
        }

        base.Activate();
    }
}
