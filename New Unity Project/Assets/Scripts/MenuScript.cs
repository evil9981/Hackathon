using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    public Button selectText;
    LevelManager levelManage = LevelManager.getInst();

    // Use this for initialization
    void Start ()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        selectText = selectText.GetComponent<Button>();
        quitMenu.enabled = false;
	}
	
    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        selectText.enabled = false;
    }

    public void SelectPress()
    {
        levelManage.go_to_level(1);
    }

    public void nextPress()
    {
        startText.enabled = false;
        exitText.enabled = false;
        selectText.enabled = false;
    }

    public void previousPress()
    {
        startText.enabled = false;
        exitText.enabled = false;
        selectText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        selectText.enabled = true;
    }

    public void StartLevel()
    {
        levelManage.go_to_level(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
