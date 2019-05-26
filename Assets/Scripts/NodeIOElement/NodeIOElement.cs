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

    private Node linkedNode;

    private Outline outline;

    [SerializeField]
    private int num;

    [SerializeField]
    private GameObject edgeGO;
    
    // In edge (input is single)
    private GameObject edge;

    [SerializeField]
    // Out edges (outputs can be many)
    public List<GameObject> edges = new List<GameObject>();

    

    void Start()
    {
        outline = GetComponent<Outline>();
    }

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
            if(SelectionManager.instance.getSelectedIO() == this){
                setOutline(false);
                SelectionManager.instance.setSelectedIO(null);
            } else {
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
                    el1.parent.GetComponent<Node>().IOElements[el1.getNum()].setLinkedNode(el2.parent.GetComponent<Node>());
                    GameObject edge = Instantiate(edgeGO);
                    el1.setEdge(edge);
                    el2.edges.Add(edge);
                    edge.GetComponent<LineRenderer>().SetPosition(0, el1.transform.position);
                    edge.GetComponent<LineRenderer>().SetPosition(1, el2.transform.position);
                    SelectionManager.instance.getSelectedIO().setOutline(false);
                    SelectionManager.instance.setSelectedIO(null);
                }
            }
        } else {
            
            SelectionManager.instance.setSelectedIO(this);
            setOutline(true);
        }
        
    }

    // public void AddEdge(GameObject _edge){
    //     edges.Add(_edge);
    // }

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

    public int getNum(){
        return num;
    }

    public ENodeIOElementType getType(){
        return type;
    }

    public Node getLinkedNode(){
        return linkedNode;
    }

    public void setLinkedNode(Node _node){
        linkedNode = _node;
    }

    public void setEdge(GameObject _edge){
        edge = _edge;
    }

    public GameObject getEdge(){
        return edge;
    }
#endregion
}
