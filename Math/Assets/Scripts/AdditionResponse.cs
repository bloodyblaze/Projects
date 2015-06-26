using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdditionResponse : MonoBehaviour 
{
	Text text;
	public int response;

	// Use this for initialization
	void Awake () 
	{  
		text = GetComponent <Text> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		response = Addition.response;
		text.text = "" + response;	
	}
}
