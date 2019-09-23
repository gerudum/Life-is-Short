using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Logic
{
    public bool held = false;
    public override void Activate()
    {
  
        if (!toggled && !held)
        {
            trigger.SetActive(false);
            toggled = true;
        }

        if (held)
        {
            trigger.SetActive(trigger.activeSelf);
        }

        base.Activate();
    }
}
