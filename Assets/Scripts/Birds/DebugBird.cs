using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBird : Bird
{
    protected override void Ability()
    {
        Debug.Log("Skill");
    }
}
