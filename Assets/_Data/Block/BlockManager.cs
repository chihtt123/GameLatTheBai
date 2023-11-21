using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] protected Transform blockPrefab;

    [SerializeField] protected Transform GameUI;

    public int rows = 3;
    public int cols = 4;

    private bool canFlip = true;

    private List<int> cardValues = new List<int>();
    [SerializeField] private List<BlockItem> flippedBLock = new List<BlockItem>();


    protected virtual void Start()
    {
        InitializeBlock();
    }

    protected virtual void InitializeBlock()
    {
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
                card.SetParent(this.GameUI);
               
            }
        }
        return; 
    }

    protected virtual void ShuffleList<T>(List<T> list)
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
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        canFlip = false;

        yield return new WaitForSeconds(1.5f); 
        if (flippedBLock[0].Value == flippedBLock[1].Value)
        {
           
        }
        else
        {
            // No match
            flippedBLock[0].UnflipCard();
            flippedBLock[1].UnflipCard();
        }

        flippedBLock.Clear();
        canFlip = true;
    }


}

   


