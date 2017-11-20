using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using System;

public class MainFieldView : View {

    internal GameObject[,] field;

    internal void Init(Func<GameObject[,]> a)
    {
        CreateMesh(a);
    }

    private void CreateMesh(Func<GameObject[,]> a)
    {
        field = a.Invoke();
    }
}
