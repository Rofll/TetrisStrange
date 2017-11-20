using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFieldMesh : MonoBehaviour {

    [Inject]
    public Config Config { get; private set; }

    public GameObject[] field { get; private set; }

    public void CreateMesh()
    {
        field = new GameObject[Config._gameConfig.FigureCount];

        GameObject Root = new GameObject();
        Root.name = "FigureMeshField";

        for (int i = 0; i < field.Length; i++)
        {
            field[i] = Instantiate(Config._gameConfig.BlockPrefab);
            field[i].transform.position = Config._gameConfig.StartPosField + new Vector3(i * Config._gameConfig.DistanceBetweenFields, 0, 0);
            field[i].transform.localScale = Config._gameConfig.FieldScale;
            field[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            field[i].GetComponent<SpriteRenderer>().sortingOrder = 1;
            field[i].transform.parent = Root.transform;
        }
    }
}
