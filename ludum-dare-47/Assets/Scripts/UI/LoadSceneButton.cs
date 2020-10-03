﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    [Inject]
    private ZenjectSceneLoader _loader;

    [Inject]
    private SignalBus _signalBus;

    public void LoadScene()
    {
        _signalBus.Fire(new StartSceneTransitionEffectSignal(OnScreenIsBlack));
    }

    private void OnScreenIsBlack()
    {
        _loader.LoadSceneAsync(sceneName, loadMode: UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}