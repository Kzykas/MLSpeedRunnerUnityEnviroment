using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

	public void exitApplication () {
        Debug.Log("has quit");
        Application.Quit();
	}
}
