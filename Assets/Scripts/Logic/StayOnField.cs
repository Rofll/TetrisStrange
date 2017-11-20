using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnField {

    [Inject]
    public UpdateFigureSignal updateFigureSignal { get; set; }

    [Inject]
    public CheckFieldSignal CheckFieldSignal { get; set; }

    [Inject]
    public DropAudioSignal DropAudioSignal { get; set; }

    [Inject]
    public CheckPossibleMove CheckPossibleMove { get; set; }

    [Inject]
    public GameOverSignal GameOverSignal { get; private set; }

    private GameObject tmp;
    private bool canStay = true;


    public void PutOnFieled(Vector3 figureStartPosition, GameObject figure, Vector3 StartScale)
    {
        tmp = figure;
        for (int i = 0; i < figure.transform.childCount - 1; i++)
        {
            figure.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
            RaycastHit2D hit = Physics2D.Raycast(figure.transform.GetChild(i).transform.position + new Vector3(0,0,2), Vector3.back);
            if (!(hit.transform != null && hit.collider.CompareTag("Block") && hit.transform.gameObject.GetComponent<Block>().OutGameObject == null))
            {
                canStay = false;
                break;
            }
        }

        if (canStay)
        {
            for (int i = 0; i < figure.transform.childCount - 1; i++)
            {
                RaycastHit2D hit = Physics2D.Raycast(figure.transform.GetChild(i).transform.position + new Vector3(0, 0, 2), Vector3.back);
                figure.transform.GetChild(i).transform.position = hit.transform.position;
                hit.transform.gameObject.GetComponent<Block>().OnAdd(figure.transform.GetChild(i).gameObject);
            }

            updateFigureSignal.Dispatch();
            CheckFieldSignal.Dispatch();
            DropAudioSignal.Dispatch();

            if (!CheckPossibleMove.Check())
                GameOverSignal.Dispatch();
        }
        else
        {
            for (int i = 0; i < figure.transform.childCount - 1; i++)
                figure.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            figure.transform.position = figureStartPosition;
            figure.transform.localScale = StartScale;
            canStay = true;
        }
    }
}
