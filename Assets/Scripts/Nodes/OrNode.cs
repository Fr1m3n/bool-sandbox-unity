using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrNode :  Node
{

    public GameObject textGO;

    public override bool f(bool a, bool b){
        return a | b;
    }

    private void initInputs(){
        IOElements.Add(null);
        IOElements.Add(null);
    }

    public void setInput(int num, NodeIOElement node){
        IOElements[num] = node;
    }

    void Start()
    {
        text = textGO.GetComponent<Text>();
    }

    

    void Update()
    {
        
    }
    
#region handlers
    public void OnClick(){
        calculate();
    }
#endregion
}
