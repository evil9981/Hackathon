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
                ingameMenu.enabled = true;
            }
            else
            {
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
}
