using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	bool pauseTog; //toggle

	public void PauseTogs (){ 	//intended for button click use
		pauseTog = !pauseTog; 
		if (pauseTog == true) {
			Time.timeScale = 0; //stop physics simulation
		}
		if (pauseTog == false) {
			Time.timeScale = 1; //full speed simulation
		}

	}

}
