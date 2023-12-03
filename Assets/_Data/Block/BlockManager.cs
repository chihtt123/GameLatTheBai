using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : ChiMonoBehaviour
{

    
    private static BlockManager instance;
    public static BlockManager Instance { get => instance; }



    [SerializeField] protected Transform blockPrefab;
    [SerializeField] protected Canvas canvas;
    [SerializeField] public  Transform gameUI;
    [SerializeField] public Transform blocks;
    [SerializeField] public Transform levelUI;
    [SerializeField] public Transform victoryUI;



    [SerializeField] private int score = 0;
    [SerializeField] public int remainingTurn;
    [SerializeField] public int correctPair;

    public int rows = 0;
    public int cols = 0;
    private bool canFlip = true;
    public bool winGame = false;
    [SerializeField] public int lockLevelCount = 1; // khoi dau level 1
    
    private List<int> cardValues = new List<int>();
    [SerializeField] private List<BlockItem> flippedBLock = new List<BlockItem>();

    [SerializeField] public Sprite[] sprites;
    [SerializeField] public Sprite[] spritesGame;



    public int Score { get => score; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCanvas();
        this.LoadBlockPrefab();
        this.LoadLevelUI();
        this.LoadGameUI();
        this.LoadBlockLevels();
        this.LoadVictoryUI();


    }



    protected override void Awake()
    {
        if (BlockManager.instance != null) Debug.LogError("Only 1 BlockManager allow to exist");
        BlockManager.instance = this;
        sprites = Resources.LoadAll<Sprite>("Image/Blocks");
        sprites = Resources.LoadAll<Sprite>("Image");
    }
    protected virtual void LoadBlockPrefab() 
     {
        if (this.blockPrefab != null) return;
        this.blockPrefab = transform.Find("Block");
        Debug.LogWarning(transform.name + " LoadBlockPrefab", gameObject);  
     }


    protected virtual void LoadGameUI()
    {
        if (this.gameUI != null) return;
        this.gameUI = this.canvas.transform.Find("GameUI");
        Debug.LogWarning(transform.name + " LoadGameUI", gameObject);
    }
    protected virtual void LoadLevelUI()
    {
        if (this.levelUI != null) return;
        this.levelUI = this.canvas.transform.Find("LevelsUI");
        Debug.LogWarning(transform.name + " LoadLevelUI", gameObject);
    }

    protected virtual void LoadBlockLevels()
    {
        if (this.blocks != null) return;
        this.blocks = this.gameUI.transform.Find("Blocks");
        Debug.LogWarning(transform.name + " LoadLevelUI", gameObject);
    }

       protected virtual void LoadVictoryUI()
    {
        if (this.victoryUI != null) return;
        this.victoryUI = this.canvas.transform.Find("VictoryUI");
        Debug.LogWarning(transform.name + " LoadVictoryUI", gameObject);
    }



    protected virtual void LoadCanvas()
    {
        if (this.canvas != null) return;
        this.canvas = BlockManager.FindObjectOfType<Canvas>();
        Debug.LogWarning(transform.name + " LoadCanvas", gameObject);
    }

 



  

      public void InitializeBlock()
    {
       
        this.remainingTurn = 10;
        this.correctPair = 0;

        blockPrefab.gameObject.SetActive(false);
        List<int> values = new List<int>();
        for (int i = 0; i < (rows * cols) / 2; i++)
        {
            values.Add(i);
            values.Add(i);
        }

        ShuffleList(values);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Transform card = Instantiate(blockPrefab, new Vector3(j, -i, 0), Quaternion.identity);
                card.GetComponent<BlockItem>().SetValue(values[i * cols + j]);
                card.gameObject.SetActive(true);
               
                card.SetParent(this.blocks);     
            }
        }
        return; 
    }

      void ShuffleList<T>(List<T> list)
    {
        int n = list.Count - 1;
        while (n > 0)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    public bool CanFlip()
    {
        return canFlip;
    }

    public void AddFlippedCard(BlockItem block)
    {
        flippedBLock.Add(block);
        Debug.Log("Game");
        if (flippedBLock.Count == 2)
        {
            remainingTurn--;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        canFlip = false;
        yield return new WaitForSeconds(1.5f); 
        if (flippedBLock[0].Value == flippedBLock[1].Value)
        {
            score+= 5;
            correctPair++;
            remainingTurn++;
            flippedBLock[0].GetComponent<Button>().interactable = false;
            flippedBLock[1].GetComponent<Button>().interactable = false;
            yield return new WaitForSeconds(0.5f);
            if(correctPair == (rows * cols) / 2)
            {
                winGame = true;
                lockLevelCount++;
                this.victoryUI.gameObject.SetActive(true);
            }
        }
        else
        {
            flippedBLock[0].UnflipCard();
            flippedBLock[1].UnflipCard();
        }

        flippedBLock.Clear();
        canFlip = true;
    }

    public void DestroyBlocks()
    {
         Transform blocks =  this.gameUI.transform.Find("Blocks");

        foreach (Transform block in blocks)
        {
            Destroy(block.gameObject);
        }

        Debug.Log("DestroyBlocks");
    }

    public void SetColumnsAndRows(int row , int col)
    {
        this.rows = row;
        this.cols = col;
    }
}

   


