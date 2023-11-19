using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.U2D;
using static UnityEditor.PlayerSettings;

public class CardSystem : CardAbstract
{

    [Header("CardSystem")]
    public int width = 3;
    public int height = 4;
    public float offsetY = 0.1f;
    public Block blocks;
    public Block blockDown;
    public List<Node> nodes;
    public List<int> nodeIds;
    public List<BlockCtrl> listBlock;
    public List<BlockCtrl> listDownBlock;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.InitCardSystem();
        this.LoadBlock();
        this.SpawnNodes();
    }

    protected override void Start()
    {
   
       this.SpawnBlock();
       this.SpawnBlockDown();

    }

    protected virtual void InitCardSystem() 
    {
        
        if (this.nodes.Count > 0) return;
        int nodeId = 0;
        for(int x = 0; x <this.width; x++)
        {
            for(int y = 0; y < this.height; y++)
            {
                Node node = new Node
                {
                    x = x,
                    y = y,
                    posY = y - (this.offsetY * y),
                    nodeId = nodeId
                };
  
                this.nodes.Add(node);
                 this.nodeIds.Add(nodeId);
                   nodeId++;
             
               
            }
        }

        
    }


    protected virtual void LoadBlock()
    {
        if (this.blocks != null) return;
        this.blocks = Resources.Load<Block>("Card");
        this.blockDown = Resources.Load<Block>("Down");
    }

    protected virtual void SpawnNodes()
    {
        Vector3 pos = Vector3.zero;
        foreach (Node node in this.nodes)
        {
            pos.x = node.x;
            pos.y = node.posY;
            
            Transform block = this.ctrl.blockSpawner.Spawn(BlockSpawner.BLOCK, pos, Quaternion.identity);
            BlockCtrl blockCtrl = block.GetComponent<BlockCtrl>();
            
            blockCtrl.blockData.setNode(node);
    

        }   
    }


    protected virtual void SpawnBlockDown()
    {
        Vector3 pos = Vector3.zero;

        foreach (Node node in this.nodes)
        {
            pos.x = node.x;
            pos.y = node.posY;
            Transform block = this.ctrl.blockSpawner.Spawn(BlockSpawner.BLOCK, pos, Quaternion.identity);
            BlockCtrl blockCtrl = block.GetComponent<BlockCtrl>();
            this.LinkNodeBlock(node, blockCtrl);
            blockCtrl.sprite.sortingLayerName = "1";
            blockCtrl.blockData.setSprite(this.blockDown.sprites[0]);
            blockCtrl.gameObject.SetActive(true);

            listDownBlock.Add(blockCtrl);
        }
    }

    protected virtual void SpawnBlock()
    {
        int blockCount = 2;
        Vector3 pos = Vector3.zero;
        foreach (Sprite sprite in this.blocks.sprites)
        {
            for(int i = 0;i < blockCount; i++)
            {

                Node node = this.getRandomNode();
                pos.x = node.x;
                pos.y = node.posY;
                Transform block = this.ctrl.blockSpawner.Spawn(BlockSpawner.BLOCK, pos, Quaternion.identity);
             
                BlockCtrl blockCtrl = block.GetComponent<BlockCtrl>();
              
                blockCtrl.sprite.sortingLayerName = "Default";
                this.LinkNodeBlock(node, blockCtrl);
                blockCtrl.blockData.setSprite(sprite);
                blockCtrl.gameObject.SetActive(true);
                listBlock.Add(blockCtrl);
            }
           
        }
       

    }



    protected virtual Node getRandomNode()
    {
        Node returnNode;
        int randId;
        
        int nodeCount = this.nodes.Count;
        for (int i = 0; i < nodeCount; i++)
        {
            randId = Random.Range(0, this.nodeIds.Count);
            returnNode = this.nodes[this.nodeIds[randId]];
            this.nodeIds.RemoveAt(randId);
            if (returnNode.blockCtrl == null) return returnNode;

        }
        Debug.LogError("Node can't found");
        return null;
    }


    protected virtual void LinkNodeBlock( Node node, BlockCtrl blockCtrl)
    { 
        blockCtrl.blockData.setNode(node);
        node.blockCtrl = blockCtrl;
    }

  


}
