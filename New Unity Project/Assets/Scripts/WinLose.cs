using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinLose : MonoBehaviour {

    protected int Condition = 0;
    public Canvas winMenu;
    public Canvas loseMenu;
    public Text pass;
    public Text gold;
    public Text noBattery;
    public Text deathByWire;
    public Button nextLevel;
    public Button winRetry;
    public Button winMainMenu;
    public Button loseRetry;
    public Button loseMainMenu;

	// Use this for initialization
	void Start () {
        winMenu = winMenu.GetComponent<Canvas>();
        loseMenu = loseMenu.GetComponent<Canvas>();
        pass = pass.GetComponent<Text>();
        gold = gold.GetComponent<Text>();
        noBattery = noBattery.GetComponent<Text>();
        deathByWire = deathByWire.GetComponent<Text>();
        nextLevel = nextLevel.GetComponent<Button>();
        winRetry = winRetry.GetComponent<Button>();
        winMainMenu = winMainMenu.GetComponent<Button>();
        loseRetry.GetComponent<Button>();
        loseMainMenu.GetComponent<Button>();
        winMenu.enabled = false;
        loseMenu.enabled = false;
        pass.enabled = false;
        gold.enabled = false;
        noBattery.enabled = false;
        deathByWire.enabled = false;
        nextLevel.enabled = false;
        winRetry.enabled = false;
        winMainMenu.enabled = false;
        loseRetry.enabled = false;
        loseMainMenu.enabled = false;      
	}
	
	// Update is called once per frame
	void Update () {
	    

	}

    void showEndOfGame(int Condition)
    {
        if (Condition == 1)
        {
            winMenu.enabled = true;
            pass.enabled = true;
            winRetry.enabled = true;
            winMainMenu.enabled = true;
            nextLevel.enabled = true;
        }
        else if (Condition == 2)
        {
            winMenu.enabled = true;
            gold.enabled = true;
            winRetry.enabled = true;
            winMainMenu.enabled = true;
            nextLevel.enabled = true;
        }
        else if (Condition == 3)
        {
            loseMenu.enabled = true;
            noBattery.enabled = true;
            loseMainMenu.enabled = true;
            loseRetry.enabled = true;
        }
        else if (Condition == 4)
        {
            loseMenu.enabled = true;
            deathByWire.enabled = true;
            loseMainMenu.enabled = true;
            loseRetry.enabled = true;
        }
    }

    public void nextLevelPress()
    {
        Application.LoadLevel(2);
    }

    public void retryPress()
    {
        Application.LoadLevel(1);
    }

    public void mainMenuPress()
    {
        Application.LoadLevel(0);
    }
}
