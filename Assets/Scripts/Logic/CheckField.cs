using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckField : MonoBehaviour {

    [Inject]
    public CreateMeshSc meshSc { get; private set; }
    private bool Flagx = true;
    private bool FlagY = true;
    private bool Both = true;

    public void Check()
    {
        GameObject[,] field = meshSc.field;
        List<GameObject> temp = new List<GameObject>();

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j].GetComponent<Block>().OutGameObject == null)
                {
                    Flagx = false;
                    break;
                }
            }

            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[j, i].GetComponent<Block>().OutGameObject == null)
                {
                    FlagY = false;
                    break;
                }
            }

            if (Flagx)
            {
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    temp.Add(field[i, j]);
                }
            }

            if (FlagY)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    temp.Add(field[j, i]);
                }
            }

            Flagx = true;
            FlagY = true;
        }

        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i].GetComponent<Block>().OutGameObject != null)
            {
                if (temp[i].GetComponent<Block>().OutGameObject.transform.parent.childCount == 2)
                {
                    if (temp[i].GetComponent<Block>().OutGameObject.transform.parent.transform.parent.childCount == 1)
                        DestroyImmediate(temp[i].GetComponent<Block>().OutGameObject.transform.parent.transform.parent.gameObject);
                    else
                        DestroyImmediate(temp[i].GetComponent<Block>().OutGameObject.transform.parent.gameObject);
                }
                else
                    temp[i].GetComponent<Block>().OnRemove();
            }
        }
    }
}
