using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrNode :  Node
{

    public override bool calculate(){
        bool res;
        if(inputs[0] != null){
            res = inputs[0].calculate();
        } else {
            //log.error("Null input in OrNode");
            return false;
        }
        for(int i = 0; i < inputs.Count; i++){
            Node a = inputs[i];
            if(a == null){
                //log.error("Null input in OrNode");
                return false;
            }
            res |= a.calculate();
        }
        return res;
    }

    private void initInputs(){
        inputs.Add(null);
        inputs.Add(null);
    }

    public void setInput(int num, Node node){
        inputs[num] = node;
    }

    // Start is called before the first frame update
    void Start()
    {
        initInputs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
