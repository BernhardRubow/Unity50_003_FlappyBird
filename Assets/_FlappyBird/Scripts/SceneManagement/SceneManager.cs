﻿using System.Collections;
using System.Collections.Generic;
using FlappyBird.Events;
using UnityEngine;
using nvp.Assets.EventHandling;
using UnityEngine.SceneManagement;

namespace FlappyBird
{
    public class SceneManager : NvpAbstractEventHandlerV2
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++




        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        void Update()
        {

        }




        // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void OnGameInitialized(object arg1, object arg2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                "_FlappyBird/Scenes/02_Hauptmenu", 
                LoadSceneMode.Additive);
        }





        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected override void StartListenToEvents()
        {
            EventController.StartListenForEvent((int)FlappyBirdEvents.OnGameInitialized, OnGameInitialized);
        }

        protected override void StopListenToEvents()
        {
            EventController.StopListenForEvent((int)FlappyBirdEvents.OnGameInitialized, OnGameInitialized);
        }

    }
}