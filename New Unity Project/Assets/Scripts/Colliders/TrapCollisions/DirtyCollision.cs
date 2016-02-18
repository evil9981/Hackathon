using UnityEngine;
using System.Collections;

public class DirtyCollision : MonoBehaviour 
{

    RoombaState roomba_state;
    // Use this for initialization
    void Start()
    {
        roomba_state = Camera.main.GetComponent<DisplayCollected>().roomba_state;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        roomba_state.exit_dirt();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        roomba_state.enter_dirt();
    } 
}
