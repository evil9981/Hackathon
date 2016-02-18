using UnityEngine;
using System.Collections;

public class RangeCollision : MonoBehaviour 
{

    RoombaState roomba_state;
	// Use this for initialization
	void Start ()
    {
        roomba_state = Camera.main.GetComponent<DisplayCollected>().roomba_state;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        roomba_state.hit_range_power_up();
        Destroy(gameObject);
    } 
}
