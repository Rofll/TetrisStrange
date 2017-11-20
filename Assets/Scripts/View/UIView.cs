using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using System;

public class UIView : View {

	internal void Init()
    {
        gameObject.SetActive(false);
    }

    internal void ShowPanel(bool flag)
    {
        gameObject.SetActive(flag);
    }
}
