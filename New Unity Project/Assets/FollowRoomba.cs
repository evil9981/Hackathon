using UnityEngine;
using System.Collections;

public class FollowRoomba : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}

    public Transform target;
    float smooth = 1;

	// Update is called once per frame
	void FixedUpdate () 
    {
        float x = Mathf.Lerp(transform.position.x, target.position.x, Time.deltaTime * smooth);
        float y = Mathf.Lerp(transform.position.y, target.position.y, Time.deltaTime * smooth);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
	}
}
