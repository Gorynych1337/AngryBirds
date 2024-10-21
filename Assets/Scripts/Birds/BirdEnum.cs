using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BirdPrefabCollection", menuName = "MySO/BirdPrefabCollection", order = 1)]
public class BirdEnum : ScriptableObject
{
    [SerializeField] private GameObject defaultBirdPrefab;
    [SerializeField] private GameObject speedBirdPrefab;
    [SerializeField] private GameObject boomBirdPrefab;
    [SerializeField] private GameObject debugBirdPrefab;

    public enum Birds
    {
        defaultBird,
        speedBird,
        boomBird,
        debug
    }

    public GameObject GetBirdPrefab(Birds bird)
    {
        switch (bird)
        {
            case Birds.defaultBird: return defaultBirdPrefab;
            case Birds.speedBird: return speedBirdPrefab;
            case Birds.boomBird: return boomBirdPrefab;
            case Birds.debug: return debugBirdPrefab;
            default: return defaultBirdPrefab;
        }
    }
}
