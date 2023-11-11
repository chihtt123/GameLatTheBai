using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardAbstract : ChiMonoBehaviour
{
    [Header("CardAbstract")]
    public CardManagerCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
      
        this.ctrl = transform.parent.GetComponent<CardManagerCtrl>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }
}
