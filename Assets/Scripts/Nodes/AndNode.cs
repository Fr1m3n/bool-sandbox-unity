using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndNode :  Node
{
    public GameObject textGO;

    public override bool f(bool a, bool b){
        return a & b;
    } 

    private void initInputs(){
        IOElements.Add(null);
        IOElements.Add(null);
    }

    public void setInput(int num, NodeIOElement node){
        IOElements[num] = node;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = textGO.GetComponent<Text>();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

#region Handlers
    public void OnClick(){
        calculate();
    }
#endregion
}
