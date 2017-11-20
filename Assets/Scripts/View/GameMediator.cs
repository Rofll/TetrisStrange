using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;

public class GameMediator : Mediator {

    [Inject]
    public GameView GameView { get; set; }

    [Inject]
    public InputMove InputMove { get; set; }

    public override void OnRegister()
    {
        GameView.InputMove(InputMove.MoveObjects);
    }
}
