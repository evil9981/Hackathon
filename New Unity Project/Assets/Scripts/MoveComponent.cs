using UnityEngine;
using System.Collections;

public class MoveComponent : MonoBehaviour 
{
    public Rigidbody2D rigid_body;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
    public int FORCE_CONST = 100;
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigid_body.AddForce(transform.up * FORCE_CONST);
        } 
        if (Input.GetKey(KeyCode.DownArrow ))
        {
            rigid_body.AddForce(-transform.up * FORCE_CONST);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid_body.MoveRotation(rigid_body.rotation + 3.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid_body.MoveRotation(rigid_body.rotation - 3.0f);
        }
	}
}
