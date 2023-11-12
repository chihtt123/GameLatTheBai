using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManagerCtrl : ChiMonoBehaviour
{
    [Header("CardManagerCtrl")]

    private static CardManagerCtrl instance;
    public static CardManagerCtrl Instance => instance;

    public BlockSpawner blockSpawner;
    public BlockCtrl firstBlock;
    public BlockCtrl secondBlock;

    protected override void Awake()
    {
        base.Awake();
        if(CardManagerCtrl.instance != null)  Debug.LogError("Only 1 CardManagerCtrl allow to exist");
        CardManagerCtrl.instance = this;
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.blockSpawner != null) return;
        this.blockSpawner = transform.Find("BlockSpawner").GetComponent<BlockSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    public virtual void SetBlock(BlockCtrl blockCtrl)
    {

        if(this.firstBlock != null && this.secondBlock != null) 
        {
            this.firstBlock = null; this.secondBlock = null;
            Debug.Log("reset blocks");
            return;
        }

        if(this.firstBlock == null)
        {
            this.firstBlock = blockCtrl;
            return;
        }

        this.secondBlock = blockCtrl;
    }



}
