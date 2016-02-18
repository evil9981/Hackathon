using UnityEngine;
using System.Collections;

public class PileOfDirtCollision : MonoBehaviour {

    public GameLogic gameLogic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        gameLogic.trashCollected();
        Destroy(gameObject);
        Debug.Log("Hit!");
    }
}
