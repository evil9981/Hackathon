using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class displayCollected : MonoBehaviour {

    public GameLogic gameLogic;
    public Sprite normal;
    public Sprite gold;
    public float x;
    public float y;
    public float scale;
    public int normalTrash;
    public int BonusTrash;
    public GameObject gray;
    int collected;

    List<GameObject> collected_display = new List<GameObject>();

    // Use this for initialization
    void Start () {
        int totalTrash = normalTrash + BonusTrash;
        
        for (int i = 0; i < totalTrash; i++) {
            float spacing = 9f / (totalTrash - 1f);
            Vector3 pos = new Vector3(x + spacing * i, y, 0.5f);
            GameObject temp = (GameObject)Instantiate(gray, transform.position, transform.rotation);
            temp.transform.parent = gameObject.transform;
            temp.transform.position = pos;
            temp.transform.localPosition = new Vector3(temp.transform.localPosition.x, temp.transform.localPosition.y, 0.4f);
            temp.transform.localScale = new Vector3(scale, scale, scale);
            collected_display.Add(temp);
        }


    }
	
	// Update is called once per frame
	void Update () {


	}

    public void change_to_collected(int num_collected)
    {
        if (num_collected <= normalTrash)
        {
            collected_display[num_collected - 1].GetComponent<SpriteRenderer>().sprite = normal;
        }
        else
        {
            collected_display[num_collected - 1].GetComponent<SpriteRenderer>().sprite = gold;
        }
    }

}
