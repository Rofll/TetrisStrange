using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using System;

public class MainFieldMediator : Mediator {

    [Inject]
    public MainFieldView mainFieldView { get; set; }

    [Inject]
    public CreateMeshSc Mesh {get; set;}

    public override void OnRegister()
    {
        mainFieldView.Init(Mesh.CreateMesh);
    }

    public override void OnRemove()
    {
        Debug.Log("Mediator OnRemove");
    }
}
