using UnityEngine;
using System.Collections;

public class RoombaState : MonoBehaviour 
{
    public int battery_level = 100;

    public InGameMenu gameMenu;
    GameLogic gameLogic;
    
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

    public Sprite saver_1;
    public Sprite saver_2;
    public Sprite saver_3;
    public Sprite saver_4;
    public Sprite saver_5;
    public Sprite saver_6;
    public Sprite saver_7;
    public Sprite saver_8;

    public Sprite shield_1;
    public Sprite shield_2;
    public Sprite shield_3;
    public Sprite shield_4;
    public Sprite shield_5;
    public Sprite shield_6;
    public Sprite shield_7;
    public Sprite shield_8;

    public Sprite range_1;
    public Sprite range_2;
    public Sprite range_3;
    public Sprite range_4;
    public Sprite range_5;
    public Sprite range_6;
    public Sprite range_7;
    public Sprite range_8;

    public SpriteRenderer powerup_sprite;
    public Sprite battery_sprite;
    public Sprite saver_sprite;
    public Sprite range_sprite;
    public Sprite shield_sprite;

	// Use this for initialization
	void Start () 
    {
        gameLogic = gameObject.GetComponent<GameLogic>();
	}
	
    bool show_empty = false;

    enum EnergyCost : int
    {
        Normal = 1, Move = 2, Dirt_move = 3, Water_move = 4
    }
    EnergyCost cost = EnergyCost.Normal;

    enum PowerUp
    {
        Battery, Shield, Range, Saver, None
    }
    PowerUp powerup_picked = PowerUp.None;
    PowerUp current_powerup = PowerUp.None;

    // Update is called once per frame
    float reduce_energy_time = 0.0f;
    float reduce_energy_cooldown = 1.0f;

    float blinking_time = 0.0f;
    float blinking_cooldown = 0.1f;

    float zoom_powerup_time = 0.0f;

    float powerup_time = 0.0f;

    float range_cooldown = 1.0f;
    float shield_cooldown = 5.0f;
    float saver_cooldown = 5.0f;

    float origOrtho = 7.0f;
    float targetOrtho = 15.0f;
    float smoothSpeed = 15.0f;

    bool do_zoom_out = true;
    bool do_zoom_in = false;
    bool do_zoom_powerup = false;
    public void zoom_out()
    {
        if (do_zoom_out)
        {
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);

            if (Camera.main.orthographicSize >= targetOrtho)
            {
                Camera.main.orthographicSize = targetOrtho;
                zoom_powerup_time = range_cooldown;
                do_zoom_out = false;
            }
        }
        else
        {
            if (do_zoom_in)
            {
                Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, origOrtho, smoothSpeed * Time.deltaTime);
                if (Camera.main.orthographicSize <= origOrtho)
                {
                    Camera.main.orthographicSize = origOrtho;
                    do_zoom_out = true;
                    do_zoom_powerup = false;
                    current_powerup = PowerUp.None;
                }
            }
            else if (zoom_powerup_time < 0)
            {
                do_zoom_in = true;
            }
        }
    }

	void Update ()
    {        
        if (!gameMenu.isPaused())
        {
            blinking_time -= Time.deltaTime;
            reduce_energy_time -= Time.deltaTime;
            powerup_time -= Time.deltaTime;
            zoom_powerup_time -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (powerup_picked == PowerUp.Range)
                {
                    do_zoom_powerup = true;
                    current_powerup = powerup_picked;
                    powerup_picked = PowerUp.None;
                }
                else if (powerup_picked == PowerUp.Saver)
                {
                    powerup_time = saver_cooldown;
                    current_powerup = powerup_picked;
                    powerup_picked = PowerUp.None;
                }
                else if (powerup_picked == PowerUp.Battery)
                {
                    battery_level = 100;
                    current_powerup = powerup_picked;
                    powerup_picked = PowerUp.None;
                }
                else if (powerup_picked == PowerUp.Shield)
                {
                    powerup_time = shield_cooldown;
                    current_powerup = powerup_picked;
                    powerup_picked = PowerUp.None;
                }
            }

            if (powerup_picked == PowerUp.Battery)
            {
                powerup_sprite.sprite = battery_sprite;
                powerup_sprite.enabled = true;
            }
            else if (powerup_picked == PowerUp.Range)
            {
                powerup_sprite.sprite = range_sprite;
                powerup_sprite.enabled = true;
            }
            else if (powerup_picked == PowerUp.Saver)
            {
                powerup_sprite.sprite = saver_sprite;
                powerup_sprite.enabled = true;
            }
            else if (powerup_picked == PowerUp.Shield)
            {
                powerup_sprite.sprite = shield_sprite;
                powerup_sprite.enabled = true;
            }
            else
            {
                powerup_sprite.enabled = false;
            }

            if (do_zoom_powerup)
            {
                zoom_out();
            }

            if (powerup_time <= 0 && !do_zoom_powerup)
            {
                current_powerup = PowerUp.None;
            }

            if (blinking_time <= 0)
            {
                blinking_time = blinking_cooldown;
                show_empty = !show_empty;
            }

            if (reduce_energy_time <= 0)
            {
                reduce_energy_time = reduce_energy_cooldown;
                if (current_powerup == PowerUp.Saver)
                {
                    battery_level -= (int)(cost - 1);
                }
                else if (current_powerup != PowerUp.Shield)
                {
                    battery_level -= (int)cost;
                }
            }

	        if (battery_level > 87.5M)
            {
                if (current_powerup == PowerUp.Saver)
                {
                    sprite_renderer.sprite = saver_8;
                }
                else if (current_powerup == PowerUp.Range)
                {
                    sprite_renderer.sprite = range_8;
                }
                else if (current_powerup == PowerUp.Shield)
                {
                    sprite_renderer.sprite = shield_8;
                }
                else
                {
                    sprite_renderer.sprite = normal_8;
                }
            }
            else if (battery_level > 75.0M)
            {
                if (current_powerup == PowerUp.Saver)
                {
                    sprite_renderer.sprite = saver_7;
                }
                else if (current_powerup == PowerUp.Range)
                {
                    sprite_renderer.sprite = range_7;
                }
                else if (current_powerup == PowerUp.Shield)
                {
                    sprite_renderer.sprite = shield_7;
                }
                else
                {
                    sprite_renderer.sprite = normal_7;
                }
            }
            else if (battery_level > 67.5M)
            {
                if (current_powerup == PowerUp.Saver)
                {
                    sprite_renderer.sprite = saver_6;
                }
                else if (current_powerup == PowerUp.Range)
                {
                    sprite_renderer.sprite = range_6;
                }
                else if (current_powerup == PowerUp.Shield)
                {
                    sprite_renderer.sprite = shield_6;
                }
                else
                {
                    sprite_renderer.sprite = normal_6;
                }
            }
            else if (battery_level > 50.0M)
            {
                if (current_powerup == PowerUp.Saver)
                {
                    sprite_renderer.sprite = saver_5;
                }
                else if (current_powerup == PowerUp.Range)
                {
                    sprite_renderer.sprite = range_5;
                }
                else if (current_powerup == PowerUp.Shield)
                {
                    sprite_renderer.sprite = shield_5;
                }
                else
                {
                    sprite_renderer.sprite = normal_5;
                }
            }
            else if (battery_level > 37.5M)
            {
                if (current_powerup == PowerUp.Saver)
                {
                    sprite_renderer.sprite = saver_4;
                }
                else if (current_powerup == PowerUp.Range)
                {
                    sprite_renderer.sprite = range_4;
                }
                else if (current_powerup == PowerUp.Shield)
                {
                    sprite_renderer.sprite = shield_4;
                }
                else
                {
                    sprite_renderer.sprite = normal_4;
                }
            }
            else if (battery_level > 25.0M)
            {
                if (current_powerup == PowerUp.Saver)
                {
                    sprite_renderer.sprite = saver_3;
                }
                else if (current_powerup == PowerUp.Range)
                {
                    sprite_renderer.sprite = range_3;
                }
                else if (current_powerup == PowerUp.Shield)
                {
                    sprite_renderer.sprite = shield_3;
                }
                else
                {
                    sprite_renderer.sprite = normal_3;
                }
            }
            else if (battery_level > 12.5M)
            {
                if (current_powerup == PowerUp.Saver)
                {
                    if (!show_empty)
                        sprite_renderer.sprite = saver_2;
                    else
                        sprite_renderer.sprite = normal_0;
                }
                else if (current_powerup == PowerUp.Range)
                {
                    if (!show_empty)
                        sprite_renderer.sprite = range_2;
                    else
                        sprite_renderer.sprite = normal_0;
                }
                else if (current_powerup == PowerUp.Shield)
                {
                    if (!show_empty)
                        sprite_renderer.sprite = shield_2;
                    else
                        sprite_renderer.sprite = normal_0;
                }
                else
                {
                    if (!show_empty)
                        sprite_renderer.sprite = normal_2;
                    else
                        sprite_renderer.sprite = normal_0;
                }
            }
            else if (battery_level > 0M)
            {
                if (current_powerup == PowerUp.Saver)
                {
                    if (!show_empty)
                        sprite_renderer.sprite = saver_1;
                    else
                        sprite_renderer.sprite = normal_0;
                }
                else if (current_powerup == PowerUp.Range)
                {
                    if (!show_empty)
                        sprite_renderer.sprite = range_1;
                    else
                        sprite_renderer.sprite = normal_0;
                }
                else if (current_powerup == PowerUp.Shield)
                {
                    if (!show_empty)
                        sprite_renderer.sprite = shield_1;
                    else
                        sprite_renderer.sprite = normal_0;
                }
                else
                {
                    if (!show_empty)
                        sprite_renderer.sprite = normal_1;
                    else
                        sprite_renderer.sprite = normal_0;
                }
            }
            else 
            {
                sprite_renderer.sprite = normal_0;
                gameLogic.noBattery();
            }
        }
	}

    public void hit_dirt()
    {
        gameLogic.trashCollected();
    }

    public void hit_battery_power_up()
    {
        powerup_picked = PowerUp.Battery;
    }

    public void hit_range_power_up()
    {
        powerup_picked = PowerUp.Range;
    }

    public void hit_shield_power_up()
    {
        powerup_picked = PowerUp.Shield;
    }

    public void hit_saver_power_up()
    {
        powerup_picked = PowerUp.Saver;
    }

    public void hit_wires()
    {
        if (current_powerup != PowerUp.Shield)
        {
            gameLogic.runOverWires();
        }
    }

    public void enter_dirt()
    {
        Debug.Log("ENTER DIRT!");
    }

    public void exit_dirt()
    {
        Debug.Log("EXIT DIRT!");
    }

    public void enter_water()
    {
        Debug.Log("ENTER WATER!");
    }

    public void exit_water()
    {
        Debug.Log("EXIT WATER!");
    }
}
