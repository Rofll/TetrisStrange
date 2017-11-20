using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;

public class UIMediator : Mediator {

    [Inject]
    public UIView UIView { get; set; }

    [Inject]
    public GameOverSignal GameOverSignal { get; set; }

    public override void OnRegister()
    {
        UIView.Init();
        GameOverSignal.AddListener(ShowPanel);
    }

    public override void OnRemove()
    {
        Debug.Log("OnRemove");
    }

    public void ShowPanel()
    {
        UIView.ShowPanel(true);
    }

    public void HidePanel()
    {
        UIView.ShowPanel(false);
    }
}
