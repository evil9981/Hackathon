using UnityEngine;
using System.Collections;

public class WaterCollision : MonoBehaviour {

    RoombaState roomba_state;
    // Use this for initialization
    void Start()
    {
        roomba_state = Camera.main.GetComponent<DisplayCollected>().roomba_state;
    }
	
	// Update is called once per frame
	void Update () 
    {
    }
	    
    void OnTriggerExit2D(Collider2D other)
    {
        roomba_state.exit_water();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        roomba_state.enter_water();
	}
}
