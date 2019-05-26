using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Node : MonoBehaviour
{
    public List<NodeIOElement> IOElements;

    public Text text;

    public virtual bool calculate(){
        Debug.Log("Start calc on " + gameObject.name);
        bool res;
        int i = 0;
        while(IOElements[i].getType() == ENodeIOElementType.Output) i++;
        res = IOElements[i].getLinkedNode().calculate();
        i++;
        Debug.Log(res.ToString() + ' ' + i.ToString());
        for(; i < IOElements.Count; i++){
            if(IOElements[i].getType() == ENodeIOElementType.Output) continue;
            Debug.Log(i.ToString() + " Start");
            Node a = (Node) IOElements[i].getLinkedNode();
            if(a == null){
                //log.error("Null input in AndNode");
                return false;
            }
            res = f(res, a.calculate());
            Debug.Log(i.ToString() + " Success with res == " + res.ToString());
        }
        text.text = res.ToString();
        Debug.Log(res.ToString());
        return res;
    }

    public abstract bool f(bool a, bool b);
}
