using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject settingsMenu;

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
        var webView = gameObject.AddComponent<UniWebView>();
        webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        webView.Load("https://uniwebview.com");
        webView.Show();
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }
}
