using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class BlockClickDown : BlockAbstract
{
    public BoxCollider boxCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.size = new Vector3(0.7f, 0.73f, 0);
        this.boxCollider.center = new Vector3(-2.2f, -0.765f, 0f);
        Debug.Log(transform.name + " LoadCollider", gameObject);
    }
    protected void OnMouseUp()
    {

        if (CardManagerCtrl.Instance != null)
        {
            CardManagerCtrl.Instance.SetBlock(this.ctrl);
        }
        else
        {
            Debug.LogError("CardManagerCtrl.Instance là null!");
        }
    }   
}
