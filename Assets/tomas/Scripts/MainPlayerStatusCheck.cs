using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayerStatusCheck : MonoBehaviour {

    public GameObject mainPlayer;
    string mainPlayerName;
    public Text gameStatus;

    public string menuName = "1.Menu";
    //Temporalilly, we get the position from CameraPivot collected player amount
    public CameraObjectFollow cameraObjectFollow; //TODO: change this bs
	// Use this for initialization
	void Start () {
        mainPlayerName = mainPlayer.name;
	}
	
	// Update is called once per frame
	void Update () {
        if (cameraObjectFollow.players.Count == 1)
        {
            if(cameraObjectFollow.players[0].name == mainPlayerName)
            {
                gameStatus.enabled = true;
                gameStatus.text = "YOU WIN!\nPress 'Space' to continue";
                LoadMenu();
            }
            else
            {
                gameStatus.enabled = true;
                gameStatus.text = "YOU LOSE!\nPress 'Space' to continue";
                LoadMenu();
            }
        }
	}

    void LoadMenu()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(menuName);
        }
    }
}
