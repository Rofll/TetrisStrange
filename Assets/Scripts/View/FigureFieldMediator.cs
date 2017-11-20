using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;

public class FigureFieldMediator : Mediator {

    [Inject]
    public FigureFieldView figureFieldView { get; set; }

    [Inject]
    public CreateFieldMesh createField { get; set; }

    [Inject]
    public UpdateFiguresField updateFields { get; set; }

    public override void OnRegister()
    {
        figureFieldView.Init(createField.field, updateFields.UpdateFigures);
    }

    public override void OnRemove()
    {
        Debug.Log("Mediator OnRemove");
    }
}
