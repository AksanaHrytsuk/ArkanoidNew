using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int blockNumbers;
    LoaderScens loaderScens;


    // Start is called before the first frame update
    void Start()
    {
        // Block[] allBlocks FindObjectOfType<Block>();
        // int blocksNumber = allBlocks.Length;
        loaderScens = FindObjectOfType<LoaderScens>();
    }

   public void AddBlockCount()
    {
        blockNumbers++;
    }

    public void RemoveBlockCount()
    {
        blockNumbers--;
        if (blockNumbers <= 0)
        {
            loaderScens.LoadNextScene();
        }
    }
}
