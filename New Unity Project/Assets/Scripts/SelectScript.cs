using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectScript : MonoBehaviour {

    LevelManager levelManage = LevelManager.getInst();
    public Button quitButton;

    // Use this for initialization
    void Start()
    {
        quitButton = quitButton.GetComponent<Button>();
    }

    public void quitPress()
    {
        levelManage.go_to_level(0);
    }
}
