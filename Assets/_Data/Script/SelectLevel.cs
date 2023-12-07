using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : ChiMonoBehaviour
{

    [SerializeField]private GridLayoutGroup gridLayoutGroup;

    [SerializeField] private Transform levels;

    [SerializeField] private List<Button> levelButtons;

    protected override void FixedUpdate()
    {
        this.LockLevel();
    }

    protected override void Start()
    {
        LoadLevelButton();
    }

    public void LoadLevelButton()
    {
        
        foreach (Transform item in levels)
        {
            levelButtons.Add(item.GetComponent<Button>());       
        }
    }
    

    public void LockLevel()
    {
        for (int i = 1; i < levelButtons.Count; i++)
        {
            levelButtons[i].interactable = false;
        }

        int level = BlockManager.Instance.lockLevelCount; ;
       


        for (int i = 0; i < level; i++)
        {
            levelButtons[i].interactable = true;
        }


    }

    public void NextLevel()
    {
        BlockManager.Instance.DestroyBlocks();
        this.LoadLevel(BlockManager.Instance.lockLevelCount);
        BlockManager.Instance.victoryUI.gameObject.SetActive(false);

    }

    public  void RestartLV(Transform UI)
    {
        BlockManager.Instance.DestroyBlocks();
        BlockManager.Instance.InitializeBlock();
        UI.gameObject.SetActive(false);
        BlockManager.Instance.gameUI.gameObject.SetActive(true);

    }
    
    

    public void ChangeGridLayoutGroup(int constraintCount, Vector2 spacing, Vector2 cellSize) 
    {
        gridLayoutGroup.constraintCount = constraintCount;
        gridLayoutGroup.cellSize = cellSize;
        gridLayoutGroup.spacing = spacing;
    }

    

    public void LoadLevel(int levelIndex)
    {
       
        switch (levelIndex)
        {
            case 1:
                BlockManager.Instance.SetColumnsAndRows(3, 4);
                gridLayoutGroup.constraintCount = 3;
                break;
            case 2:
                BlockManager.Instance.SetColumnsAndRows(4, 4);
                this.ChangeGridLayoutGroup(4, new Vector2(15f, 15f), new Vector2(180f, 180f));
                break;
            case 3:
                    BlockManager.Instance.SetColumnsAndRows(4, 5);
                     this.ChangeGridLayoutGroup(4, new Vector2(15f, 15f), new Vector2(170f, 170f));
                break;
            case 4:
                BlockManager.Instance.SetColumnsAndRows(5, 6);
                this.ChangeGridLayoutGroup(5, new Vector2(10f, 10f), new Vector2(150f, 150f));
                break;
            case 5:
                BlockManager.Instance.SetColumnsAndRows(6, 6);
                this.ChangeGridLayoutGroup(6, new Vector2(10f, 10f), new Vector2(150f, 150f));
                break;
        }
      
        this.transform.gameObject.SetActive(false);
        BlockManager.Instance.InitializeBlock();
        BlockManager.Instance.gameUI.gameObject.SetActive(true);





    }

}
