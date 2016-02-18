using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinLose : MonoBehaviour {

    int Condition = 0;
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
	void Update () 
    {
	    
	}

    public int WIN = 1;
    public int WIN_GOLD = 2;
    public int LOSE_BATTERY = 3;
    public int LOSE_WIRES = 4;

    void showEndOfGame(int Condition)
    {
        if (Condition == WIN)
        {
            winMenu.enabled = true;
            pass.enabled = true;
            winRetry.enabled = true;
            winMainMenu.enabled = true;
            nextLevel.enabled = true;
        }
        else if (Condition == WIN_GOLD)
        {
            winMenu.enabled = true;
            gold.enabled = true;
            winRetry.enabled = true;
            winMainMenu.enabled = true;
            nextLevel.enabled = true;
        }
        else if (Condition == LOSE_BATTERY)
        {
            loseMenu.enabled = true;
            noBattery.enabled = true;
            loseMainMenu.enabled = true;
            loseRetry.enabled = true;
        }
        else if (Condition == LOSE_WIRES)
        {
            loseMenu.enabled = true;
            deathByWire.enabled = true;
            loseMainMenu.enabled = true;
            loseRetry.enabled = true;
        }
    }

    public void nextLevelPress()
    {
        LevelManager.getInst().advanceToNextLevel();
    }

    public void retryPress()
    {
        LevelManager.getInst().retryLevel();
    }

    public void mainMenuPress()
    {
        LevelManager.getInst().quitToMenu();
    }
}
