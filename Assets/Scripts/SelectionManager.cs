using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

#region Variables
    public static SelectionManager instance;
    private NodeIOElement selectedIO; 
    
#endregion

    void Start()
    {
        // Singleton
        if(instance == null){
            instance = this;
        }    
    }

    void Update()
    {
        
    }    

#region Getters/Setters
    public void setSelectedIO(NodeIOElement _element){
        selectedIO = _element;
    }
    public NodeIOElement getSelectedIO(){
        return selectedIO;
    }
#endregion
}
