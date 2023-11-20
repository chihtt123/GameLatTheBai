using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] protected Transform blockPrefab;

    [SerializeField] protected Transform blockManager;


    public int rows = 3;
    public int cols = 4;



    [SerializeField] List<Transform> blocks = new List<Transform>();
    private List<int> cardValues = new List<int>();
    private Transform selectedCard;


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
                card.SetParent(this.transform);
                blocks.Add(card);
            }
        }
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




}

   


