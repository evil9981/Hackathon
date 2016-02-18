﻿using UnityEngine;
using System.Collections;

public class RoombaState : MonoBehaviour 
{
    decimal battery_level = 27.0M;
    public InGameMenu gameMenu;
    
    public SpriteRenderer sprite_renderer;

    public Sprite normal_0;
    public Sprite normal_1;
    public Sprite normal_2;
    public Sprite normal_3; 
    public Sprite normal_4;
    public Sprite normal_5;
    public Sprite normal_6;
    public Sprite normal_7;
    public Sprite normal_8;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
    private float reduce_energy_time = 0.0f;
    public float reduce_energy_cooldown = 1.0f;

    private float blinking_time = 0.0f;
    public float blinking_cooldown = 0.1f;

    decimal surface_reduction = 1.0M;

    bool show_empty = false;

	void Update ()
    {
        if (!gameMenu.isPaused())
        {
            blinking_time -= Time.deltaTime;
            reduce_energy_time -= Time.deltaTime;

            if (battery_level < 25.0M && blinking_time <= 0)
            {
                blinking_time = blinking_cooldown;
                show_empty = !show_empty;
            }

            if (reduce_energy_time <= 0)
            {
                reduce_energy_time = reduce_energy_cooldown;
                battery_level -= surface_reduction;
                Debug.Log(battery_level);
            }

	        if (battery_level > 87.5M)
            {
                sprite_renderer.sprite = normal_8;
            }
            else if (battery_level > 75.0M)
            {
                sprite_renderer.sprite = normal_7;
            }
            else if (battery_level > 67.5M)
            {
                sprite_renderer.sprite = normal_6;
            }
            else if (battery_level > 50.0M)
            {
                sprite_renderer.sprite = normal_5;
            }
            else if (battery_level > 37.5M)
            {
                sprite_renderer.sprite = normal_4;
            }
            else if (battery_level > 25.0M)
            {
                sprite_renderer.sprite = normal_3;
            }
            else if (battery_level > 12.5M)
            {
                if (!show_empty)
                    sprite_renderer.sprite = normal_2;
                else
                    sprite_renderer.sprite = normal_0;
            }
            else if (battery_level > 0M)
            {
                if (!show_empty)
                    sprite_renderer.sprite = normal_1;
                else
                    sprite_renderer.sprite = normal_0;
            }
            else 
            {
                sprite_renderer.sprite = normal_0;
            }
        }
	}
}