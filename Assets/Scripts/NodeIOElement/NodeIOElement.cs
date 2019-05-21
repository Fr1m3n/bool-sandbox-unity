using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class NodeIOElement : MonoBehaviour
{
    
    [SerializeField]
    private ENodeIOElementType type;

    [SerializeField]
    private GameObject parent;

    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(){
        /*
        ** Если мы выделили 2 IO элемента одного типа (output - output), то переключим выделение
        ** Иначе создадим связь
        ** TODO: Сделать создание связи перетаскиванием
        */
        if(SelectionManager.instance.getSelectedIO() != null){
            if(SelectionManager.instance.getSelectedIO().getType() == type){
                SelectionManager.instance.getSelectedIO().setOutline(false); 
                setOutline(true);
                SelectionManager.instance.setSelectedIO(this);
            } else {
                NodeIOElement el1 = this;
                NodeIOElement el2 = SelectionManager.instance.getSelectedIO();
                // el1 - IN, el2 - OUT
                if(el1.type == ENodeIOElementType.Output){
                    NodeIOElement _temp = el1;
                    el1 = el2;
                    el2 = _temp;
                }

            }
            
        }
        
    }

#region Getters/Setters
    public void setOutline(bool _state){
        outline.enabled = _state;
    }

    public void setParent(GameObject _parent){
        parent = _parent;
    }

    public void setType(ENodeIOElementType _type){
        type = _type;
    }

    public ENodeIOElementType getType(){
        return type;
    }
#endregion
}
