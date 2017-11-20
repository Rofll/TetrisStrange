using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

public class AppStartCommand : Command {

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    [Inject]
    public CreateFieldMesh createField { get; set; }

    [Inject]
    public InputMove InputMove { get; private set; }

    public override void Execute()
    {
        GameObject go = new GameObject();
        GameObject go2 = new GameObject();
        GameObject go3 = new GameObject();
        go.name = "MainFieldView";
        go2.name = "FigureFieldView";
        go3.name = "GameView";
        go.AddComponent<MainFieldView>();
        go2.AddComponent<FigureFieldView>();
        go3.AddComponent<GameView>();
        go.transform.parent = contextView.transform;
        go2.transform.parent = contextView.transform;
        go3.transform.parent = contextView.transform;
        InputMove.CanMove = true;

        createField.CreateMesh();
        Debug.Log("App start command!");

        //
    }
}
