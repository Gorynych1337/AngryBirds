using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBird : Bird
{
    [SerializeField] private float accelerationMod;

    protected override void Ability()
    {
        acceleration *= accelerationMod;
    }
}
