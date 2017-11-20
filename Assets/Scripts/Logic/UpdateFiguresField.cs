using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFiguresField : MonoBehaviour {

    [Inject]
    public Config Config { get; private set; }

    [Inject]
    public CreateFieldMesh createField { get; set; }

    public GameObject[] figures { get; private set; }

    private int FigureCount = 0;
    private Quaternion quaternion;

    public void UpdateFigures()
    {
        if (FigureCount == 0)
        {
            figures = new GameObject[Config._gameConfig.FigureCount];
            GameObject Root = new GameObject();
            Root.name = "Figures";

            for (int i = 0; i < figures.Length; i++)
            {
                figures[i] = Instantiate(Config._gameConfig.Figures[Random.Range(0, Config._gameConfig.Figures.Length - 1)]) as GameObject;
                Rotate();
                figures[i].transform.rotation = quaternion;
                figures[i].transform.position = createField.field[i].transform.position + Vector3.back;
                figures[i].transform.localScale = Config._gameConfig.StartFigureScale;
                figures[i].transform.parent = Root.transform;

                for (int j = 0; j < figures[i].transform.childCount - 1; j++)
                {
                    figures[i].transform.GetChild(j).gameObject.AddComponent<BoxCollider2D>();
                    figures[i].transform.GetChild(j).transform.tag = "Figure";
                    figures[i].transform.GetChild(j).GetComponent<SpriteRenderer>().sortingOrder = 2;
                }

                GameObject pivot = figures[i].transform.Find("Pivot").gameObject;
                Vector3 tmp = new Vector3();
                tmp = pivot.transform.localPosition;

                if (figures[i].transform.rotation.eulerAngles.z == 180)
                    tmp = new Vector3(-tmp.x, -tmp.y, tmp.z);
                else if (quaternion.eulerAngles.z == 90)
                    tmp = new Vector3(-tmp.y, tmp.x, tmp.z);
                else if (quaternion.eulerAngles.z == 270)
                    tmp = new Vector3(tmp.y, -tmp.x, tmp.z);

                figures[i].transform.position = figures[i].transform.position - tmp / 1.5f;

            }

            FigureCount = figures.Length - 1;
        }

        else
        {
            FigureCount--;
        }
    }

    private void Rotate()
    {
        int n = Random.Range(0, 4);

        switch (n)
        {
            case 0:
                quaternion = Quaternion.Euler(0, 0, 0);
                break;
            case 1:
                quaternion = Quaternion.Euler(0, 0, 90);
                break;
            case 2:
                quaternion = Quaternion.Euler(0, 0, 180);
                break;
            default:
                quaternion = Quaternion.Euler(0, 0, 270);
                break;
        }
    }
}
