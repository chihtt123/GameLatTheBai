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
    public BlockCtrl downBlockOne;
    public BlockCtrl downBlockTwo;
    protected CardSystem cardSystem;


    protected override void Awake()
    {
        base.Awake();
        if(CardManagerCtrl.instance != null)  Debug.LogError("Only 1 CardManagerCtrl allow to exist");
        CardManagerCtrl.instance = this;
    }

   
    protected override void Reset()
    {
        base.Reset();
        this.downBlockOne = null;
        this.downBlockTwo = null;   
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadCardSystem();
    }

    protected  void Update()
    {
      //  this.DeleteTheSameBlock();
    }
    protected virtual void LoadCardSystem()
    {
        if (cardSystem != null) return;
        this.cardSystem = GetComponentInChildren<CardSystem>();
        Debug.Log(transform.name + "LoadCardSystem", gameObject);
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
           // DeleteTheSameBlock();
            this.firstBlock = null; this.secondBlock = null;
            Debug.Log("reset blocks");
            return;
        }
        

        if(this.downBlockOne == null)
        {
            this.downBlockOne = blockCtrl;
            this.downBlockOne.gameObject.SetActive(false);
        }
                
      
        if(this.secondBlock != null)
        {
            this.downBlockTwo = blockCtrl;
        }



        foreach (BlockCtrl block in this.cardSystem.listBlock)
            {
                if (block.blockData.node.nodeId.Equals(blockCtrl.blockData.node.nodeId))
                {
                    if (this.firstBlock == null)
                    {
                        this.firstBlock = block;
                        return;
                    }
                    this.secondBlock = block;
                    return;
            }
           
           }
        

    

       
    }


    public virtual void DeleteTheSameBlock()
    {

        if (this.firstBlock!=null && this.secondBlock !=  null ) 
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
                this.downBlockOne.gameObject.SetActive(true);
                this.downBlockTwo.gameObject.SetActive(true);
            }
    
        }
       
      
     

       
        
        

    }
}
