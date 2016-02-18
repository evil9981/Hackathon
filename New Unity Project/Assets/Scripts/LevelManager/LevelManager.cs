using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager  
{
    static private LevelManager instance = new LevelManager();
    bool[] level_complete = new bool[20];
    bool[] level_gold_complete = new bool[20];

	// Use this for initialization
    public LevelManager() 
    {
        LevelManager.instance = this;
	}

    static public LevelManager getInst()
    {
        return LevelManager.instance;
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
