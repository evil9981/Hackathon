using UnityEngine;
using System.Collections;

public class Youwin : MonoBehaviour {

    LevelManager levelManager = LevelManager.getInst();

    public void go_to_main()
	{
		levelManager.go_to_level (0);
	}

}
