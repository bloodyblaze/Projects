using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdditionEquation : MonoBehaviour 
{
	Text text;
	public int a;
	public int b;
	// Use this for initialization
	void Awake () 
	{  
		text = GetComponent <Text> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		a = Addition.a;
		b = Addition.b;
		text.text = a + " + " + b + " = " ;	
	}
}