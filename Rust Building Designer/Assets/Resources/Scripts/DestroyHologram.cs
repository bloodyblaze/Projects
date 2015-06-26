using UnityEngine;
using System.Collections;

public class DestroyHologram : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		BuildingSpawner.destroyHologram = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(BuildingSpawner.destroyHologram == true)
		{
			Destroy(this.gameObject);
		}
	
	}
}
