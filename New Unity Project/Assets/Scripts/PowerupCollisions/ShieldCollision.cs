using UnityEngine;
using System.Collections;

public class ShieldCollision : MonoBehaviour 
{

    RoombaState roomba_state;
	// Use this for initialization
	void Start () 
    {
        roomba_state = gameObject.GetComponentInParent<PowerupHandler>().roomba_state;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        roomba_state.hit_shield_power_up();
        Destroy(gameObject);
    } 
}
