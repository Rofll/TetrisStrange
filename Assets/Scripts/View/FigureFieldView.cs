using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using System;

public class FigureFieldView : View {


    [Inject]
    public Config Config { get; private set; }

    private GameObject[] _field;

    internal void Init(GameObject[] mesh, Action a)
    {
        CreateMesh(mesh);
        UpdateFigures(a);
    }

    private void CreateMesh(GameObject[] mesh)
    {
        _field = mesh;
    }

    internal void UpdateFigures(Action a)
    {
        a.Invoke();
    }
}
