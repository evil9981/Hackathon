using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour 
{

    int collectedTrash = 0;
    public int passCondition;
    public int totalPass;
    public displayCollected display;

    public InGameMenu menu;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void noBattery()
    {
        if (collectedTrash == totalPass)
        {
            menu.showEndOfGame(menu.WIN_GOLD);
        }
        else if (collectedTrash >= passCondition)
        {
            menu.showEndOfGame(menu.WIN);
        }
        else 
        {
            menu.showEndOfGame(menu.LOSE_BATTERY);
        }
    }

    public void trashCollected()
    {
        collectedTrash += 1;
        display.change_to_collected(collectedTrash);

        if (collectedTrash == totalPass)
        {
            menu.showEndOfGame(menu.WIN_GOLD);
        }
    }

    public void runOverWires()
    {
        menu.showEndOfGame(menu.LOSE_WIRES);
    }

    public int getCollected()
    {
        return collectedTrash;
    }


}
