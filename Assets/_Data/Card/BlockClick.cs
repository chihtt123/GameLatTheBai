using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class BlockClick : BlockAbstract
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
        this.boxCollider.size = new Vector3(0.7f, 0.7f, 0);
        this.boxCollider.center = new Vector3(-1.3f, -0.3f, 0f);
        Debug.Log(transform.name + " LoadCollider", gameObject);
    }
    protected void OnMouseUp()
    {

        CardManagerCtrl.Instance.SetBlock(this.ctrl);
    }

    
}
