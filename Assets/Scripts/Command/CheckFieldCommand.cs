using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

public class CheckFieldCommand : Command {

    [Inject]
    public CheckField CheckField { get; private set; }

    public override void Execute()
    {
        CheckField.Check();
    }
}
