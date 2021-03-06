﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameMenu : MonoBehaviour 
{

    public Canvas ingameMenu;
    public Button resumeGame;
    public Button quitToMain;
    public Button resetLevel;

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
    LevelManager level_manager;

	// Use this for initialization
	void Start ()
    {
        level_manager = LevelManager.getInst();

        ingameMenu.enabled = false;

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

        resume_game();
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

    public int WIN = 1;
    public int WIN_GOLD = 2;
    public int LOSE_BATTERY = 3;
    public int LOSE_WIRES = 4;

    public void showEndOfGame(int Condition)
    {
        pause_game();

        if (Condition == WIN)
        {
            level_manager.levelComplete();

            winMenu.enabled = true;
            pass.enabled = true;
            winRetry.enabled = true;
            winMainMenu.enabled = true;
            nextLevel.enabled = true;
        }
        else if (Condition == WIN_GOLD)
        {
            level_manager.levelGoldComplete();

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
        level_manager.advanceToNextLevel();
    }

    public void retryPress()
    {
        level_manager.retryLevel();
    }

    public void mainMenuPress()
    {
        level_manager.quitToMenu();
    }

    public void QuitPress()
    {
        level_manager.quitToMenu();
    }
  
    public void ResumePress()
    {
        ingameMenu.enabled = false;
    }

    public void ResetLevel()
    {
        level_manager.retryLevel();
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
