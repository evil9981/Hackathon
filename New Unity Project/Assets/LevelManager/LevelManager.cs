using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager  
{
    static private LevelManager instance = new LevelManager();

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
