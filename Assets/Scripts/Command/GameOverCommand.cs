using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;

public class GameOverCommand : Command {

    [Inject]
    public InputMove InputMove { get; private set; }

    public override void Execute()
    {
        InputMove.CanMove = false;
    }
}
