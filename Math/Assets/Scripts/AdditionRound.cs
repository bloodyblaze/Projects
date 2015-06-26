using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdditionRound : MonoBehaviour 
{
	Text text;
	public int round;
	
	// Use this for initialization
	void Awake () 
	{  
		text = GetComponent <Text> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		round = Addition.round;
		text.text = "" + round;	
	}
}