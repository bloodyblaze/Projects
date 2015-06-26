using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour 
{
	public int gemType;
	public Color gemColor;
	private RaycastHit uphit,downhit,upLefthit, upRighthit, downLefthit, downRighthit;
	public float upTag, downTag, upLeftTag, upRightTag, downLeftTag, downRightTag;
	public Renderer rend;
	public static bool Isfalling = false;
	public bool SwapCheck = false;

	void Start () 
	{
		//set GemType and color
		#region
		rend = GetComponent<Renderer> ();

		gemType = Random.Range (1, 7);

		if(gemType == 1)
		{
			//color = Resources.Load ("Materials/"+"Red") as Material;
			gameObject.tag="Red";
			gemColor = Color.red;
		}
		if (gemType == 2) {
			//color = Resources.Load ("Materials/"+"Blue") as Material;
			gameObject.tag="Blue";
			gemColor = Color.blue;
		}
		if(gemType == 3)
		{
			//color = Resources.Load ("Materials/"+"Green") as Material;
			gameObject.tag="Green";
			gemColor = Color.green;
		}
		if(gemType == 4)
		{
			//color = Resources.Load ("Materials/"+"Yellow") as Material;
			gameObject.tag="Yellow";
			gemColor = Color.yellow;
		}
		if(gemType == 5)
		{
			//color = Resources.Load ("Materials/"+"Purple") as Material;
			gameObject.tag="Purple";
			gemColor = new Color(146,0,255,255);
		}
		if(gemType == 6)
		{
			//color = Resources.Load ("Materials/"+"Orange") as Material;
			gameObject.tag="Orange";
			gemColor = new Color(255,253,0,1);
		}

		rend.material.color = gemColor;

		#endregion
	}

	void Update () 
	{
		SwapCheck = Swapper.isSwapping;
		if (SwapCheck == false) 
		{
			Raycasting ();
		}

		Behaviours ();
		

	}

	void Raycasting()
	{	
		//Raycasts
		#region
		Physics.Raycast (transform.localPosition, new Vector3 (0, -1f, 0), out downhit, .505f);
		Physics.Raycast (transform.localPosition, new Vector3 (0, 1, 0), out uphit, .5f);
		Physics.Raycast (transform.localPosition, new Vector3 (Mathf.Sqrt (3) / 4, .25f, 0), out upRighthit, .5f);
		Physics.Raycast (transform.localPosition, new Vector3 (Mathf.Sqrt (3) / 4, -.25f, 0), out downRighthit, .5f);
		Physics.Raycast (transform.localPosition, new Vector3 (-Mathf.Sqrt (3) / 4, .25f, 0), out upLefthit, .5f);
		Physics.Raycast (transform.localPosition, new Vector3 (-Mathf.Sqrt (3) / 4, .25f, 0), out upLefthit, .5f);
		Physics.Raycast (transform.localPosition, new Vector3 (-Mathf.Sqrt (3) / 4, -.25f, 0), out downLefthit, .5f);
		#endregion

		if (downhit.rigidbody != null) 
		{
			Isfalling = false;
			
			if (downhit.collider.gameObject.CompareTag ("Red")) {
				downTag = 1;
			}
			if (downhit.collider.gameObject.CompareTag ("Blue")) {
				downTag = 2;
			}
			if (downhit.collider.gameObject.CompareTag ("Green")) {
				downTag = 3;
			}
			if (downhit.collider.gameObject.CompareTag ("Yellow")) {
				downTag = 4;
			}
			if (downhit.collider.gameObject.CompareTag ("Purple")) {
				downTag = 5;
			}
			if (downhit.collider.gameObject.CompareTag ("Orange")) {
				downTag = 6;
			}

			
		}
		else {
			Isfalling = true;
			transform.Translate (0, -.05f, 0);
		}
		if (Isfalling == false) 
		{	
			//setting the tags from the raycast if Gem isn't falling
			#region

			if (uphit.rigidbody != null) 
			{
				if (uphit.collider.gameObject.CompareTag ("Red")) {
					upTag = 1;
				}
				if (uphit.collider.gameObject.CompareTag ("Blue")) {
					upTag = 2;
				}
				if (uphit.collider.gameObject.CompareTag ("Green")) {
					upTag = 3;
				}
				if (uphit.collider.gameObject.CompareTag ("Yellow")) {
					upTag = 4;
				}
				if (uphit.collider.gameObject.CompareTag ("Purple")) {
					upTag = 5;
				}
				if (uphit.collider.gameObject.CompareTag ("Orange")) {
					upTag = 6;
				}
		
			}
			if (upRighthit.rigidbody != null) 
			{
				if (upRighthit.collider.gameObject.CompareTag ("Red")) {
					upRightTag = 1;
				}
				if (upRighthit.collider.gameObject.CompareTag ("Blue")) {
					upRightTag = 2;
				}
				if (upRighthit.collider.gameObject.CompareTag ("Green")) {
					upRightTag = 3;
				}
				if (upRighthit.collider.gameObject.CompareTag ("Yellow")) {
					upRightTag = 4;
				}
				if (upRighthit.collider.gameObject.CompareTag ("Purple")) {
					upRightTag = 5;
				}
				if (upRighthit.collider.gameObject.CompareTag ("Orange")) {
					upRightTag = 6;
				}
			
			}
			if (downRighthit.rigidbody != null) 
			{
				if (downRighthit.collider.gameObject.CompareTag ("Red")) {
					downRightTag = 1;
				}
				if (downRighthit.collider.gameObject.CompareTag ("Blue")) {
					downRightTag = 2;
				}
				if (downRighthit.collider.gameObject.CompareTag ("Green")) {
					downRightTag = 3;
				}
				if (downRighthit.collider.gameObject.CompareTag ("Yellow")) {
					downRightTag = 4;
				}
				if (downRighthit.collider.gameObject.CompareTag ("Purple")) {
					downRightTag = 5;
				}
				if (downRighthit.collider.gameObject.CompareTag ("Orange")) {
					downRightTag = 6;
				}
			
			}
			if (upLefthit.rigidbody != null) 
			{
				if (upLefthit.collider.gameObject.CompareTag ("Red")) {
					upLeftTag = 1;
				}
				if (upLefthit.collider.gameObject.CompareTag ("Blue")) {
					upLeftTag = 2;
				}
				if (upLefthit.collider.gameObject.CompareTag ("Green")) {
					upLeftTag = 3;
				}
				if (upLefthit.collider.gameObject.CompareTag ("Yellow")) {
					upLeftTag = 4;
				}
				if (upLefthit.collider.gameObject.CompareTag ("Purple")) {
					upLeftTag = 5;
				}
				if (upLefthit.collider.gameObject.CompareTag ("Orange")) {
					upLeftTag = 6;
				}
			
			}
			if (downLefthit.rigidbody != null) 
			{			
				if (downLefthit.collider.gameObject.CompareTag ("Red")) {
					downLeftTag = 1;
				}
				if (downLefthit.collider.gameObject.CompareTag ("Blue")) {
					downLeftTag = 2;
				}
				if (downLefthit.collider.gameObject.CompareTag ("Green")) {
					downLeftTag = 3;
				}
				if (downLefthit.collider.gameObject.CompareTag ("Yellow")) {
					downLeftTag = 4;
				}
				if (downLefthit.collider.gameObject.CompareTag ("Purple")) {
					downLeftTag = 5;
				}
				if (downLefthit.collider.gameObject.CompareTag ("Orange")) {
					downLeftTag = 6;
				}

			}

			#endregion
		}


	}
	void Behaviours()
	{
			if (upTag == downTag && upLeftTag == downTag && upRightTag == downTag && downLeftTag == downTag && downRightTag == downTag) 
			{

				Destroy (uphit.transform.gameObject);
				Destroy (upLefthit.transform.gameObject);
				Destroy (upRighthit.transform.gameObject);
				Destroy (downLefthit.transform.gameObject);
				Destroy (downRighthit.transform.gameObject);
			    Destroy (downhit.transform.gameObject);

			}

			if (gemType == upTag && upTag == upRightTag) 
			{

				Destroy (uphit.transform.gameObject);
				Destroy (upRighthit.transform.gameObject);
			    Destroy (this.gameObject);

			}
			if (gemType == upRightTag && upRightTag == downRightTag) 
			{
				Destroy (uphit.transform.gameObject);
				Destroy (upRighthit.transform.gameObject);
				Destroy (this.gameObject);
			}

			if (gemType == downTag && downTag == downRightTag) 
			{
				Destroy (downhit.transform.gameObject);
				Destroy (downRighthit.transform.gameObject);
				Destroy (this.gameObject);
			}


	}
	

}
