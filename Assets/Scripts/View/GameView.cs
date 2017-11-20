using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using System;

public class GameView : View {

    Action Move;

	void Update ()
    {
        Move.Invoke();
	}

    internal void InputMove(Action a)
    {
        Move = a;
    }
}
