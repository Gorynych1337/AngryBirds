using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevelBtn : MonoBehaviour
{
    [SerializeField] private int sceneBuildIndex;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
