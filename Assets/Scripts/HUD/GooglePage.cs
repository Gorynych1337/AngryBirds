using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooglePage : MonoBehaviour
{
    [SerializeField] private UniWebView webView;
    [SerializeField] private string startUrl;

    private void OnEnable()
    {
        webView.Load(startUrl);
        webView.Show();
    }
}
