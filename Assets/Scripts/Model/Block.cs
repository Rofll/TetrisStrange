using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IBlock {

    public GameObject OutGameObject { get; private set; }

    public void OnAdd(GameObject outer)
    {
        OutGameObject = outer;
    }

    public void OnRemove()
    {
        DestroyImmediate(OutGameObject);
    }
}
