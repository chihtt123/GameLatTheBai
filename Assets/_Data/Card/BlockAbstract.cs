using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAbstract : ChiMonoBehaviour
{
    [Header("BlockAbstract")]
    public BlockCtrl ctrl;

    protected override void LoadComponents()
    {


        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;

        this.ctrl = transform.parent.GetComponent<BlockCtrl>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }
}
