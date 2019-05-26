using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimitiveNode :  Node
{

    public GameObject textGO;

    [SerializeField]
    private bool state = true;

    public override bool calculate(){
        return state;
    }

    public override bool f(bool a, bool b){
        return false;
    }

    public void updateText(){
        text.text = state.ToString();
    }

    public void changeState(){
        state = !state;
        updateText();
    }

    public void setState(bool _state){
        state = _state;
    }

    public bool getState(){
        return state;
    }

    void Start(){
        text = textGO.GetComponent<Text>();
        updateText();
        
    }
}
