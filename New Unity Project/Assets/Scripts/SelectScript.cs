using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class SelectScript : MonoBehaviour {

    LevelManager levelManager = LevelManager.getInst();
    List<Button> stages = new List<Button>();
    public Button quitButton;

    // Use this for initialization
    void Start()
    {
        quitButton = quitButton.GetComponent<Button>();
        var list = gameObject.GetComponentsInChildren<Button>();
        foreach(var btn in list)
        {
            Debug.Log(btn.GetComponentInChildren<Text>().text);
           
            btn.enabled = false;
            btn.image.color = Color.gray;
        }


    }

    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            if (levelManager.level_gold_complete[i])
            {
                stages[i].image.color = Color.yellow;
                stages[i].enabled = true;
            }

            else if (levelManager.level_complete[i])
            {
                stages[i].image.color = Color.green;
                stages[i].enabled = true;
            }
        }
    }

    public void quitPress()
    {
        levelManager.go_to_level(0);
    }

    public void stage1Selected()
    {
        levelManager.go_to_level(1);
    }

    public void stage2Selected()
    {
        levelManager.go_to_level(2);
    }

    public void stage3Selected()
    {
        levelManager.go_to_level(3);
    }

    public void stage4Selected()
    {
        levelManager.go_to_level(4);
    }

    public void stage5Selected()
    {
        levelManager.go_to_level(5);
    }

    public void stage6Selected()
    {
        levelManager.go_to_level(6);
    }

    public void stage7Selected()
    {
        levelManager.go_to_level(7);
    }

    public void stage8Selected()
    {
        levelManager.go_to_level(8);
    }

    public void stage9Selected()
    {
        levelManager.go_to_level(9);
    }

    public void stage10Selected()
    {
        levelManager.go_to_level(10);
    }
}
