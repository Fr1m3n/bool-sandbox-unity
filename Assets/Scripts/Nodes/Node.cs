using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Node : MonoBehaviour
{
    public List<NodeIOElement> IOElements;

    public Text text;

    public virtual bool calculate(){
        bool res;
        int i = 0;
        while(IOElements[i].getType() == ENodeIOElementType.Output) i++;
        res = IOElements[i].getLinkedNode().calculate();
        i++;
        for(; i < IOElements.Count; i++){
            Node a = (Node) IOElements[i].getLinkedNode();
            if(a == null){
                //log.error("Null input in AndNode");
                return false;
            }
            res = f(res, a.calculate());
        }
        text.text = res.ToString();
        return res;
    }

    public abstract bool f(bool a, bool b);
}
