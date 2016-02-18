using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

public class SelectScript : MonoBehaviour {

    LevelManager levelManager = LevelManager.getInst();
    public Button quitButton;
    public Sprite greenc;
    public Sprite goldc;
    Image img;

    // Use this for initialization
    void Awake()
    {
        
        quitButton = quitButton.GetComponent<Button>();
        var list = gameObject.GetComponentsInChildren<Button>();
        foreach(var btn in list)
        {
            img = btn.gameObject.GetComponentInChildren<Image>();
            string name = btn.GetComponentInChildren<Text>().text;
            string num_str = Regex.Replace(name, @"[^\d]", "");
            int num = int.Parse(num_str) - 1 ;

            if (!levelManager.level_complete[num])
            {
                btn.enabled = false;
                Debug.Log("failed" + num);
               
            }
            else
            {
                Debug.Log("succeeded" + num);
                btn.enabled = true;
                //btn.image.color = Color.white;
                img.sprite = greenc;
                //btn.image.overrideSprite = Sprite.Create(Resources.Load<Texture2D>("green-check"), btn.image.sprite.rect, btn.image.sprite.pivot);                  
            }

            if (levelManager.level_gold_complete[num])
            {
                img.sprite = goldc;
                //btn.image.overrideSprite = Sprite.Create(Resources.Load<Texture2D>("gold-check"), btn.image.sprite.rect, btn.image.sprite.pivot);
            }
        }


    }

    void Update()
    {

    }

    public void quitPress()
    {
        levelManager.go_to_level(0);
    }

    public void stage1Selected()
    {
        levelManager.go_to_level(3);
    }

    public void stage2Selected()
    {
        levelManager.go_to_level(4);
    }

    public void stage3Selected()
    {
        levelManager.go_to_level(5);
    }

    public void stage4Selected()
    {
        levelManager.go_to_level(6);
    }

    public void stage5Selected()
    {
        levelManager.go_to_level(7);
    }

    public void stage6Selected()
    {
        levelManager.go_to_level(8);
    }

    public void stage7Selected()
    {
        levelManager.go_to_level(9);
    }

    public void stage8Selected()
    {
        levelManager.go_to_level(10);
    }

    public void stage9Selected()
    {
        levelManager.go_to_level(11);
    }

    public void stage10Selected()
    {
        levelManager.go_to_level(12);
    }
}
