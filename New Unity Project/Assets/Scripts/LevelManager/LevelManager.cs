using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager  
{
    static private LevelManager instance = new LevelManager();
    public bool[] level_complete = new bool[20];
    public bool[] level_gold_complete = new bool[20];

	// Use this for initialization
    public LevelManager() 
    {
        LevelManager.instance = this;
	}

    static public LevelManager getInst()
    {
        return LevelManager.instance;
    }


    public void go_to_level(int to_level)
    {
        level = to_level;
        SceneManager.LoadScene(level);
    }

    static int level = 0;
    public void levelComplete()
    {
        level_complete[level] = true;
    }

    public void levelGoldComplete()
    {
        level_gold_complete[level] = true;
    }

    public void advanceToNextLevel()
    {
        level++;
        SceneManager.LoadScene(level);
    }
    int MENU = 0;
    public void quitToMenu()
    {
        level = MENU;
        SceneManager.LoadScene(level);
    }

    public void retryLevel()
    {
        SceneManager.LoadScene(level);
    }
}
