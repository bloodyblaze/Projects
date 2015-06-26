using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour 
{
	private RaycastHit swapperHitone,swapperHittwo, swapperHitthree;
	public float tagOne,tagTwo,tagThree;


	public static bool isSwapping = false;

	private float Starttime;
	public float swapTime = 1f;



	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isSwapping == false) 
		{
			raycasting ();
		} 
		else 
		{

		}
	}

	
	void raycasting()
	{
		if (Physics.Raycast (transform.localPosition, transform.TransformDirection (1, 0, 0), out swapperHitone, .5f)) 
		{
			if(swapperHitone.collider.gameObject.CompareTag("Red"))
			{
				tagOne = 1;
			}
			if(swapperHitone.collider.gameObject.CompareTag("Blue"))
			{
				tagOne = 2;
			}
			if(swapperHitone.collider.gameObject.CompareTag("Green"))
			{
				tagOne = 3;
			}
			if(swapperHitone.collider.gameObject.CompareTag("Yellow"))
			{
				tagOne = 4;
			}
			if(swapperHitone.collider.gameObject.CompareTag("Purple"))
			{
				tagOne = 5;
			}
			if(swapperHitone.collider.gameObject.CompareTag("Orange"))
			{
				tagOne = 6;
			}

		}

		if (Physics.Raycast (transform.localPosition, transform.TransformDirection (-Mathf.Sqrt (2), Mathf.Sqrt (2), 0), out swapperHittwo, .5f)) 
		{
			if(swapperHittwo.collider.gameObject.CompareTag("Red"))
			{
				tagTwo = 1;
			}
			if(swapperHittwo.collider.gameObject.CompareTag("Blue"))
			{
				tagTwo = 2;
			}
			if(swapperHittwo.collider.gameObject.CompareTag("Green"))
			{
				tagTwo = 3;
			}
			if(swapperHittwo.collider.gameObject.CompareTag("Yellow"))
			{
				tagTwo = 4;
			}
			if(swapperHittwo.collider.gameObject.CompareTag("Purple"))
			{
				tagTwo = 5;
			}
			if(swapperHittwo.collider.gameObject.CompareTag("Orange"))
			{
				tagTwo = 6;
			}
		}


		if (Physics.Raycast (transform.localPosition, transform.TransformDirection (-Mathf.Sqrt (2), -Mathf.Sqrt (2), 0), out swapperHitthree, .5f)) 
		{
			if(swapperHitthree.collider.gameObject.CompareTag("Red"))
			{
				tagThree = 1;
			}
			if(swapperHitthree.collider.gameObject.CompareTag("Blue"))
			{
				tagThree = 2;
			}
			if(swapperHitthree.collider.gameObject.CompareTag("Green"))
			{
				tagThree = 3;
			}
			if(swapperHitthree.collider.gameObject.CompareTag("Yellow"))
			{
				tagThree = 4;
			}
			if(swapperHitthree.collider.gameObject.CompareTag("Purple"))
			{
				tagThree = 5;
			}
			if(swapperHitthree.collider.gameObject.CompareTag("Orange"))
			{
				tagThree = 6;
			}

		}


	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			isSwapping = true;
			Starttime = Time.time;
			//FirstGem();

		}

		
		if (Input.GetMouseButtonDown (1)) 
		{
			isSwapping = true;
			Starttime = Time.time;

		}
			


	}

	//void FirstGem()
	//{
		//Vector3 center = (TransGemOne.position - TransGemTwo.position) * .5f;
		//Vector3 riseRelCenter = TransGemOne.position - center;
		//Vector3 setRelCenter = TransGemTwo.position - center;
		//float fracComplete = (Time.time - Starttime) / swapTime;
		//swapperHitone.transform.position = Vector3.Slerp (riseRelCenter, setRelCenter, fracComplete);
	//	swapperHitone.transform.position += center;
	//}
	void SecondGem()
	{

	}
	void ThirdGem()
	{

	}

}
