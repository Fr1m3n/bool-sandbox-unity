using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrNode :  Node
{

    public GameObject textGO;
    private Text text;

    public override bool calculate(){
        bool res;
        if(inputs[0] != null){
            Node q = inputs[0];
            res = inputs[0].calculate();
        } else {
            return false;
        }
        for(int i = 0; i < inputs.Count; i++){
            Node a = (Node) inputs[i];
            if(a == null){
                return false;
            }
            res |= a.calculate();
        }
        text.text = res.ToString();
        return res;
    }

    private void initInputs(){
        inputs.Add(null);
        inputs.Add(null);
    }

    public void setInput(int num, Node node){
        inputs[num] = node;
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
