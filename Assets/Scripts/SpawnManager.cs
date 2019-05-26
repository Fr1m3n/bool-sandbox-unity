using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    public void spawnNode(GameObject _node){
        GameObject newNode = Instantiate(_node);
        newNode.transform.SetParent(canvas.transform);
        newNode.name += Random.Range(0, 1000).ToString();
    }
}
