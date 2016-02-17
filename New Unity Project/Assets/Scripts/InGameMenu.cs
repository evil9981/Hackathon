using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameMenu : MonoBehaviour {

    public Canvas ingameMenu;
    public Button resumeGame;
    public Button quitToMain;

	// Use this for initialization
	void Start ()
    {
        ingameMenu = ingameMenu.GetComponent<Canvas>();
        resumeGame = resumeGame.GetComponent<Button>();
        quitToMain = quitToMain.GetComponent<Button>();
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
        Application.LoadLevel(0);
    }
  
    public void ResumePress()
    {
        ingameMenu.enabled = false;

    }  
}
