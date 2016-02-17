using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    static private LevelManager instance = new LevelManager();

	// Use this for initialization
	void Start () 
    {
        LevelManager.instance = this;
	}

    static public LevelManager getInst()
    {
        return LevelManager.instance;
    }

    int level = 0;
    public void advanceToNextLevel()
    {
        level++;
        Application.LoadLevel(level);
    }
    int MENU = 0;
    public void quitToMenu()
    {
        Application.LoadLevel(MENU);
    }

    public void retryLevel()
    {
        Application.LoadLevel(level);
    }
}
