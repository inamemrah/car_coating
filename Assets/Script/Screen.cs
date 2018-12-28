using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour {

    public GameObject ColorPanel;
    public GameObject SettingsPanel;

	// Use this for initialization
	void Start () {
        ColorPanel.SetActive(true);
        SettingsPanel.SetActive(false);
	}
    void Update()
    {
        
    }
	
    public void ColorPanel_()
    {
        ColorPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    public void SettingsPanel_()
    {
        SettingsPanel.SetActive(true);
        ColorPanel.SetActive(false);
       
    }
    public void Exit_()
    {
        ColorPanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }

	
}
