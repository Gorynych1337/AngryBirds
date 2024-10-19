using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlightSettings", menuName = "MySO/FlightSettings", order = 1)]
public class FlightSettings : ScriptableObject
{
    [SerializeField] public float minPull;
    [SerializeField] public float maxPull;
    [SerializeField] public float acceleration;
    [SerializeField] public float gravityMod;
}
