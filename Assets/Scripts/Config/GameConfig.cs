using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "CreateGameConfig")]
public class GameConfig : ScriptableObject {

    public Vector3 StartPosBlockMesh;
    public Vector3 StartPosFigure;
    public Vector3 StartPosField;
    public float DistanceBetweenBlocks;
    public float DistanceBetweenFields;
    public float DistanceBetweenFigures;
    public int MeshX;
    public int MeshY;
    public int FigureCount;
    public Vector3 FieldScale;
    public Vector3 MeshBlockScale;
    public Vector3 StartFigureScale;

    public GameObject BlockPrefab;
    public GameObject[] Figures;
}
