using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Node : MonoBehaviour
{
    public List<Node> inputs;

    public abstract bool calculate();
}
