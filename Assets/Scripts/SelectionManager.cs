using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

#region Variables
    public static SelectionManager instance;

    [SerializeField]
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

    // TODO: Перенести логику выделения из NodeIOElement в эту ф-ю
    public void selectIO(NodeIOElement _el){
        
    }

    // TODO: Описать логику снятия выделения
    public void deselectIO(){

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
