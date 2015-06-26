using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Addition : MonoBehaviour 
{
	public static float timer;
	public float startTime;
	public static int round;
	public float score = 0;
	public bool roundover;
	public static int a;
	public static int b;
	public int olda;
	public static int response;
	public int c;
	public bool gameover;
	public float totalScore;
	public GameObject OneObject;
	public GameObject TwoObject;
	public GameObject ThreeObject;
	public GameObject FourObject;
	public GameObject FiveObject;
	public bool ASpawned;
	public bool BSpawned;
	public GameObject cloneA;
	public GameObject cloneB;
    public GameObject cloneC;
	
	
	
	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
		gameover = false;
		roundover = false;
		ASpawned = false;
		BSpawned = false;
		round = 1;
		a = Random.Range(0,6);
		b = Random.Range(1,6);
          cloneC = Instantiate(Plus, new Vector3( 0, 0, 0), Quaternion.identity) as GameObject;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer = Time.time - startTime;
		
		if (a == 1 && ASpawned == false) 
		{
			cloneA = Instantiate(OneObject, new Vector3( -4f, 3f, 0), Quaternion.identity) as GameObject;
			ASpawned = true;
		}
		if (a == 2 && ASpawned == false) 
		{
			cloneA = Instantiate(TwoObject, new Vector3( -4f, 3f, 0), Quaternion.identity) as GameObject;
			ASpawned = true;
		}
		if (a == 3 && ASpawned == false) 
		{
			cloneA = Instantiate(ThreeObject, new Vector3( -4f, 3f, 0), Quaternion.identity) as GameObject;
			ASpawned = true;
		}
		if (a == 4 && ASpawned == false) 
		{
			cloneA = Instantiate(FourObject, new Vector3( -4f, 3f, 0), Quaternion.identity) as GameObject;
			ASpawned = true;
		}
		if (a == 5 && ASpawned == false) 
		{
			cloneA = Instantiate(FiveObject, new Vector3( -4f, 3f, 0), Quaternion.identity) as GameObject;
			ASpawned = true;
		}
		if (b == 1 && BSpawned == false) 
		{
			cloneB = Instantiate(OneObject, new Vector3( 4f, 3f, 0), Quaternion.identity) as GameObject;
			BSpawned = true;
		}
		if (b == 2 && BSpawned == false) 
		{
			cloneB = Instantiate(TwoObject, new Vector3( 4f, 3f, 0), Quaternion.identity) as GameObject;
			BSpawned = true;
		}
		if (b == 3 && BSpawned == false) 
		{
			cloneB = Instantiate(ThreeObject, new Vector3( 4f, 3f, 0), Quaternion.identity) as GameObject;
			BSpawned = true;
		}
		if (b == 4 && BSpawned == false) 
		{
			cloneB = Instantiate(FourObject, new Vector3( 4f, 3f, 0), Quaternion.identity) as GameObject;
			BSpawned = true;
		}
		if (b == 5 && BSpawned == false) 
		{
			cloneB = Instantiate(FiveObject, new Vector3( 4f, 3f, 0), Quaternion.identity) as GameObject;
			BSpawned = true;
		}
		
		
		if(roundover == true)
		{
			Destroy(cloneB);
			Destroy(cloneA);
			c = a + b;
			if(c == response)
			{
				score = score + 1f;
			}
			olda = a;
			a = Random.Range(0,11);
			b = Random.Range(1,11);
			if(olda == a)
			{
				if(a==10)
				{
					a=a-1;
				}
				else
				{
					a=a+1;
				}
			}
			
			ASpawned = false;
			BSpawned = false;
			round = round + 1;
			roundover = false;
			response = 0;
			
		}
		
		if (gameover == false) 
		{
			if (round == 21) 
			{
				gameover = true;
				totalScore = score *10000 / timer;
				
			}
		}
	}
	public void ZeroPressed() 
	{
		if (response != 0) 
		{
			response = response *10;
		}
	}
	public void OnePressed() 
	{
		if (response == 0) 
		{
			response = 1;
		}
		else
		{
			response = response * 10 + 1;
		}
	}
	public void TwoPressed() 
	{
		if (response == 0) 
		{
			response = 2;
		}
		else
		{
			response = response * 10 + 2;
		}
	}
	public void ThreePressed() 
	{
		if (response == 0) 
		{
			response = 3;
		}
		else
		{
			response = response * 10 + 3;
		}
	}
	public void FourPressed() 
	{
		if (response == 0) 
		{
			response = 4;
		}
		else
		{
			response = response * 10 + 4;
		}
	}
	public void FivePressed() 
	{
		if (response == 0) 
		{
			response = 5;
		}
		else
		{
			response = response * 10 + 5;
		}
	}
	public void SixPressed() 
	{
		if (response == 0) 
		{
			response = 6;
		}
		else
		{
			response = response * 10 + 6;
		}
	}
	public void SevenPressed() 
	{
		if (response == 0) 
		{
			response = 7;
		}
		else
		{
			response = response * 10 + 7;
		}
	}
	public void EightPressed() 
	{
		if (response == 0) 
		{
			response = 8;
		}
		else
		{
			response = response * 10 + 8;
		}
	}
	public void NinePressed() 
	{
		if (response == 0) 
		{
			response = 9;
		}
		else
		{
			response = response * 10 + 9;
		}
	}
	public void ClearPressed() 
	{
		response = 0;
	}
	public void AcceptPressed()
	{
		roundover = true;
	}
}