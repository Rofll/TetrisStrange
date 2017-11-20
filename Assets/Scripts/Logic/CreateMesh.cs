using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMeshSc : MonoBehaviour {

    [Inject]
    public Config Config { get; private set; }

    public GameObject[,] field { get; private set; }

    public GameObject[,] CreateMesh()
    {
        field = new GameObject[Config._gameConfig.MeshY, Config._gameConfig.MeshX];

        float x = Config._gameConfig.StartPosBlockMesh.x;
        float y = Config._gameConfig.StartPosBlockMesh.y;

        GameObject Root = new GameObject();
        Root.name = "MainMeshField";

        for (int i = 0; i < Config._gameConfig.MeshY; i++)
        {
            for (int j = 0; j < Config._gameConfig.MeshX; j++)
            {
                field[i, j] = Instantiate(Config._gameConfig.BlockPrefab) as GameObject;
                field[i, j].gameObject.name = "Block";
                field[i, j].transform.position = new Vector3(x, y, 0);
                field[i, j].transform.localScale = Config._gameConfig.MeshBlockScale;
                x += Config._gameConfig.DistanceBetweenBlocks;
                field[i, j].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                field[i, j].GetComponent<SpriteRenderer>().sortingOrder = 1;
                field[i, j].gameObject.AddComponent<BoxCollider2D>();
                field[i, j].transform.parent = Root.transform;
                field[i, j].transform.tag = "Block";
                field[i, j].AddComponent<Block>();
            }

            y += Config._gameConfig.DistanceBetweenBlocks;
            x = Config._gameConfig.StartPosBlockMesh.x; ;
        }

        return field;
    }
}
