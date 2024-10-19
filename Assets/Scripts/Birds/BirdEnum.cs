using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BirdPrefabCollection", menuName = "MySO/BirdPrefabCollection", order = 1)]
public class BirdEnum : ScriptableObject
{
    [SerializeField] private GameObject defaultBirdPrefab;
    [SerializeField] private GameObject debugBirdPrefab;

    public enum Birds
    {
        defaultBird,
        debug,
    }

    public GameObject GetBirdPrefab(Birds bird)
    {
        switch (bird)
        {
            case Birds.defaultBird: return defaultBirdPrefab;
            case Birds.debug: return debugBirdPrefab;
            default: return defaultBirdPrefab;
        }
    }
}
