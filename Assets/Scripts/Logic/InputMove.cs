using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMove
{

    [Inject]
    public StayOnField StayOnField { get; set; }

    [Inject]
    public ClickAudioSignal ClickAudioSignal { get; set; }

    public bool CanMove { get; set; }

    private GameObject tmp;
    private Vector3 tmpVector = Vector3.zero;
    private Vector3 StartPos;
    private Vector3 StartScale;
    private Vector3 temp;

    public void MoveObjects()
    {
        if (CanMove)
#if UNITY_EDITOR
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPoint.z = -1;
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector3.zero);

                if (hit.transform != null && hit.collider.CompareTag("Figure") && tmp == null)
                {
                    StartPos = hit.transform.parent.position;
                    tmp = hit.transform.gameObject;
                    tmp.transform.position = hit.transform.position;
                    StartScale = tmp.transform.parent.localScale;
                    tmp.transform.parent.localScale = new Vector3(1, 1, 1);
                    temp = tmp.transform.parent.Find("Pivot").gameObject.transform.localPosition;

                    if (tmp.transform.parent.rotation.eulerAngles.z == 180.0f)
                        temp = new Vector3(-temp.x, -temp.y, temp.z);
                    else if (tmp.transform.parent.rotation.eulerAngles.z == 90.0f)
                        temp = new Vector3(-temp.y, temp.x, temp.z);
                    else if (tmp.transform.parent.rotation.eulerAngles.z == 270.0f)
                        temp = new Vector3(temp.y, -temp.x, temp.z);

                    ClickAudioSignal.Dispatch();
                }

                else if (tmp != null)
                    tmp.transform.parent.position = worldPoint - temp / 1.5f;

            }

            else if (Input.GetMouseButtonUp(0) && tmp != null)
            {
                StayOnField.PutOnFieled(StartPos, tmp.transform.parent.gameObject, StartScale);
                tmp = null;
            }

#else
        if (Input.touchCount == 1)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            worldPoint.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector3.zero);

            switch (Input.GetTouch(0).phase)
            {
                case (TouchPhase.Began):
                    if (hit.transform != null && hit.collider.CompareTag("Figure") && tmp == null)
                    {
                        tmp = hit.transform.gameObject;
                        tmp.transform.position = hit.transform.position;
                        tmp.transform.parent.localScale = new Vector3(1, 1, 1);
                        temp = tmp.transform.parent.Find("Pivot").gameObject.transform.localPosition;

                        if (tmp.transform.parent.rotation.eulerAngles.z == 180.0f)
                            temp = new Vector3(-temp.x, -temp.y, temp.z);
                        else if (tmp.transform.parent.rotation.eulerAngles.z == 90.0f)
                            temp = new Vector3(-temp.y, temp.x, temp.z);
                        else if (tmp.transform.parent.rotation.eulerAngles.z == 270.0f)
                            temp = new Vector3(temp.y, -temp.x, temp.z);

                        ClickAudioSignal.Dispatch();
                    }
                    break;
                case (TouchPhase.Moved):
                    if(tmp != null)
                        tmp.transform.parent.position = worldPoint - temp / 1.5f;
                    break;
                case (TouchPhase.Ended):
                    StayOnField.PutOnFieled(StartPos, tmp.transform.parent.gameObject);
                    tmp = null;
                    DropAudioSignal.Dispatch();
                    break;
#endif
        }
    }
}