using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameMenu : MonoBehaviour {

    public Canvas ingameMenu;
    public Button resumeGame;
    public Button quitToMain;
    public Button resetLevel;

	// Use this for initialization
	void Start ()
    {
        ingameMenu.enabled = false;
	}
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ingameMenu.enabled == false)
            {
                pause_game();
                ingameMenu.enabled = true;
            }
            else
            {
                resume_game();
                ingameMenu.enabled = false;
            }
        }
    }

    public void QuitPress()
    {
        LevelManager.getInst().quitToMenu();
    }
  
    public void ResumePress()
    {
        ingameMenu.enabled = false;
    }

    public void ResetLevel()
    {
        LevelManager.getInst().retryLevel();
    }

    public void pause_game()
    {
        paused = true;
        Time.timeScale = 0;
    }

    public void resume_game()
    {
        paused = false;
        Time.timeScale = 1;
    }

    bool paused = false;
    public bool isPaused()
    {
        return paused;
    }
}
