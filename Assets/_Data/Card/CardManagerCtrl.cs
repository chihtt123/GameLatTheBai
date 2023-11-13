using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

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

        this.Detroy();
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected  void Update()
    {
        this.DeleteTheSameBlock();
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


    public virtual void DeleteTheSameBlock()
    {

        if(this.firstBlock!=null && this.secondBlock  !=  null ) 
        {
            SpriteRenderer spriteOne = this.firstBlock.GetComponentInChildren<SpriteRenderer>();
            SpriteRenderer spriteTwo = this.secondBlock.GetComponentInChildren<SpriteRenderer>();
            if (spriteOne.sprite.name.Equals(spriteTwo.sprite.name))
            {
                firstBlock.gameObject.SetActive(false);
                secondBlock.gameObject.SetActive(false);
                this.firstBlock = null; this.secondBlock = null;
                return; 
            }
            else
            {
                this.firstBlock = null; this.secondBlock = null;
            }
           
        }
        
    }


}
