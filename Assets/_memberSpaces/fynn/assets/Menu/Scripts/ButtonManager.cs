﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using nvp.Assets.EventHandling;
using System;

public class ButtonManager : NvpAbstractEventHandlerV2
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public Text starttext;
    public Text settingstext;
    public GameObject menuCanvas;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void Start()
    {
        base.Start();
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void onStartButtonPressed()
    {
        
        starttext.text = "LOADING...";
        this.gameObject.SetActive(false);
        EventController.TriggerEvent(
            EventIdNorm.Hash("Pietro", "onstartbutton"),
            this,
            "Hello, World");
    }

    public void onSettingsButtonPressed()
    {
        EventController.TriggerEvent(
            EventIdNorm.Hash("Pietro","onsettingsbutton"), 
            this, 
            "Hello, World!");
        settingstext.text = "loading...";
    }

    void onResetLoadingTexts(object sender, object data)
    {
        starttext.text = "START";
        settingstext.text = "settings";
    }

    private void onMainMenuButton(object arg0, object arg1)
    {
        menuCanvas.SetActive(true);
    }


    // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent(
            EventIdNorm.Hash("marius", "backToMenu"),
            onResetLoadingTexts);
        EventController.StartListenForEvent(
            EventIdNorm.Hash("marius", "onmainmenubutton"),
            onMainMenuButton);
    }

    protected override void StopListenToEvents()
    {
        EventController.StopListenForEvent(
            EventIdNorm.Hash("marius", "backToMenu"),
            onResetLoadingTexts);
        EventController.StopListenForEvent(
            EventIdNorm.Hash("marius", "onmainmenubutton"),
            onMainMenuButton);
    }

}
