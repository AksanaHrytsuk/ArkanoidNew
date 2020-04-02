using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int blockNumbers;
    public float loadLevelDelay = 1f;
    LoaderScens loaderScens;

    // Start is called before the first frame update
    void Start()
    {
        // Block[] allBlocks FindObjectsOfType<Block>();
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
        if (blockNumbers == 0)
        {
            Time.timeScale = 0.5f;
            Invoke(nameof(LoadNextLevel), loadLevelDelay);
        }
    }

    private void LoadNextLevel()
    {
        loaderScens.LoadNextScene();
    }
}
