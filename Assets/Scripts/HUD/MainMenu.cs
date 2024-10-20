using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject googlePage;

    private void Start()
    {
        levelMenu.SetActive(false);
        settingsMenu.SetActive(false);
        googlePage.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenLevels()
    {
        levelMenu.SetActive(true);
    }

    public void CloseLevels()
    {
        levelMenu.SetActive(false);
    }

    public void OpenGoogle()
    {
        googlePage.SetActive(true);
    }

    public void CloseGoogle()
    {
        googlePage.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }
}
