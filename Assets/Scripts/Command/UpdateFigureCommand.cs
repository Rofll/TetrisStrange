using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

public class UpdateFigureCommand : Command {

    [Inject]
    public UpdateFiguresField UpdateFiguresField { get; private set; }

    public override void Execute()
    {
        UpdateFiguresField.UpdateFigures();
    }
}
