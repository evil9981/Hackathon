using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour 
{

    int collectedTrash = 0;
    public int passCondition;
    public int totalPass;
    public displayCollected display;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void noBattery(InGameMenu menu)
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
    }

    public int getCollected()
    {
        return collectedTrash;
    }


}
