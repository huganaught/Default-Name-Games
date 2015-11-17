using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour {

	public Text textObj; // Text object
	
	// Type library of words
	string[] subjText = {"You","The monster","The dragon","The lost city","The woods","The great sword"};
	string[] verbText = {"stubble upon", "find", "run into", "hurt", "damage", "kill", "heal", "does nothing"};
	string[] adjText = {"smells", "looks stange", "shines"};
	string[] actionText = {"fight", "attack", "sit before", "eat before", "speak to"};
	string[] nounText = {"you", "a monster", "a dragon", "the lost city", "a forest", "a knife", "a sword", "food", "itself"};
	

	string pickWord (string[] wordList){ // Chooses a random word from given library
		return wordList[Mathf.RoundToInt(Random.Range(0, wordList.Length-1))];
	}
	//For diffrent 'states'/situations diffrent libraries
	
	/*
	string resultSentence (int state) {
		if (state == 1) {
			subjText[0] + pickWord (verbYouText) + " "
		
	}
	*/

	void Start () {
		textObj.text = subjText[0] + " " + pickWord(verbText) + " " + pickWord(nounText);// Display sentence to object
	}
}