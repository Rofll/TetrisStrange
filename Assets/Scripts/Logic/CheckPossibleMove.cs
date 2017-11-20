using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPossibleMove : MonoBehaviour {

    [Inject]
    public UpdateFiguresField UpdateFiguresField { get; private set; }

    [Inject]
    public CreateMeshSc meshSc { get; private set; }

    public bool Check()
    {
        Vector3 tmp;
        Vector3 temp;
        bool hasMoves = false;

        for (int i = 0; i < UpdateFiguresField.figures.Length; i++)
        {
            if (UpdateFiguresField.figures[i] != null && UpdateFiguresField.figures[i].transform.position.y < meshSc.field[0,0].transform.position.y)
            {
                tmp = UpdateFiguresField.figures[i].transform.position;
                temp = UpdateFiguresField.figures[i].transform.localScale;

                for (int j = 0; j < meshSc.field.GetLength(0); j++)
                {
                    for (int k = 0; k < meshSc.field.GetLength(1); k++)
                    {
                        UpdateFiguresField.figures[i].transform.position = meshSc.field[j, k].transform.position + Vector3.back;
                        UpdateFiguresField.figures[i].transform.localScale = new Vector3(1, 1, 1);

                        for (int l = 0; l < UpdateFiguresField.figures[i].transform.childCount - 1; l++)
                        {
                            UpdateFiguresField.figures[i].transform.GetChild(l).gameObject.GetComponent<BoxCollider2D>().enabled = false;

                            RaycastHit2D hiter = Physics2D.Raycast(UpdateFiguresField.figures[i].transform.GetChild(l).transform.position + new Vector3(0, 0, 2), Vector3.back);
                            if (hiter.transform != null && hiter.collider.CompareTag("Block") && hiter.transform.gameObject.GetComponent<Block>().OutGameObject == null)
                                hasMoves = true;
                            else
                            {
                                UpdateFiguresField.figures[i].transform.GetChild(l).gameObject.GetComponent<BoxCollider2D>().enabled = true;
                                hasMoves = false;
                                break;
                            }

                            UpdateFiguresField.figures[i].transform.GetChild(l).gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        }

                        UpdateFiguresField.figures[i].transform.position = tmp;
                        UpdateFiguresField.figures[i].transform.localScale = temp;

                        if (hasMoves)
                        {
                            hasMoves = false;
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }
}
