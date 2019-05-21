using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndNode :  Node
{
    public GameObject textGO;
    private Text text;

    public override bool calculate(){
        bool res;
        if(inputs[0] != null){
            Node q = inputs[0];
            res = inputs[0].calculate();
        } else {
            //log.error("Null input in AndNode");
            return false;
        }
        for(int i = 0; i < inputs.Count; i++){
            Node a = (Node) inputs[i];
            if(a == null){
                //log.error("Null input in AndNode");
                return false;
            }
            res &= a.calculate();
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
        text = textGO.GetComponent<Text>();
    }

    public void OnClick(){
        text.text = calculate().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
