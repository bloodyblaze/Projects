using UnityEngine;
using System.Collections;

public class gameBoard: MonoBehaviour 
{
	public Transform gemObject;
	public Transform boardObject;
	public Transform SwapperObject;

	public int x = 10;
	public int y = 10;
	private float posX = 0;
	private float posY = 0;
	private float offset = Mathf.Sqrt (3);
	Vector3 SwapperRot;
	public static bool GemSpawned = false;


	void Start()
	{
		for (int k = 0; k < x; k++)
		{
			if (k % 2 == 0) 
			{
				posX = k;
				posY = -.5f;
			} 
			else 
			{
				posX = k;
				posY = -1f;
			}
			Vector3 pos = new Vector3 (posX * offset / 2, posY, 0);
			Instantiate (boardObject, pos, Quaternion.identity);
		}


		for (int i = 0; i < x; i++) 
		{
			for (int j = 0; j< y; j++) 
			{
				if (i % 2 == 0) 
				{
					posX = i;
					posY = j +.5f;
				} 
				else 
				{
					posX = i;
					posY = j;
				}
				Vector3 pos = new Vector3 (posX * offset / 2, posY, 0);
				Instantiate (gemObject, pos, Quaternion.identity);

				if(i == x-1)
				{
					GemSpawned = true;
				}
			}
		}


		for (int t = 0; t < (x-1)*2; t++) 
		{
			for (int a = 0; a<y-1; a++) 
			{
				if(t == 0)
				{
					posX = Mathf.Sqrt (3)/6;
					posY = a +1;
				}
				else if(t<3)
				{
					posX = t * Mathf.Sqrt (3)/3;
					posY = a + .5f;
				}
				else if(t==3)
				{
					posX = (t +2) * Mathf.Sqrt (3)/6 ;
					posY = a +1;
				}
				else if(t==4)
				{
					posX = (t + 3) * Mathf.Sqrt (3)/6 ;
					posY = a +1;
				}
				else if(t==5)
				{
					posX = (t + 3) * Mathf.Sqrt (3)/6 ;
					posY = a +.5f;
				}
				else if(t==6)
				{
					posX = (t + 4) * Mathf.Sqrt (3)/6 ;
					posY = a +.5f;
				}
				else if(t==7)
				{
					posX = (t + 4) * Mathf.Sqrt (3)/6 ;
					posY = a +1;
				}
				else if(t==8)
				{
					posX = (t + 5) * Mathf.Sqrt (3)/6 ;
					posY = a +1;
				}
				else if(t==9)
				{
					posX = (t + 5) * Mathf.Sqrt (3)/6 ;
					posY = a +.5f;
				}
				else if(t==10)
				{
					posX = (t + 6) * Mathf.Sqrt (3)/6 ;
					posY = a +.5f;
				}
				else if(t==11)
				{
					posX = (t + 6) * Mathf.Sqrt (3)/6 ;
					posY = a +1f;
				}
				else if(t==12)
				{
					posX = (t + 7) * Mathf.Sqrt (3)/6 ;
					posY = a +1f;
				}
				else if(t==13)
				{
					posX = (t + 7) * Mathf.Sqrt (3)/6 ;
					posY = a +.5f;
				}
				else if(t==14)
				{
					posX = (t + 8) * Mathf.Sqrt (3)/6 ;
					posY = a +.5f;
				}
				else if(t==15)
				{
					posX = (t + 8) * Mathf.Sqrt (3)/6 ;
					posY = a +1f;
				}
				else if(t==16)
				{
					posX = (t + 9) * Mathf.Sqrt (3)/6 ;
					posY = a +1f;
				}
				else if(t==17)
				{
					posX = (t + 9) * Mathf.Sqrt (3)/6 ;
					posY = a +.5f;
				}
				else if(t==18)
				{
					posX = (t + 10) * Mathf.Sqrt (3)/6 ;
					posY = a +.5f;
				}
				else if(t==19)
				{
					posX = (t + 10) * Mathf.Sqrt (3)/6 ;
					posY = a +1f;
				}
				else if(t==20)
				{
					posX = (t + 11) * Mathf.Sqrt (3)/6 ;
					posY = a +1f;
				}

				if(t%2 == 0)
				{
					SwapperRot = new Vector3(0,0,0);
				}
				else
				{
					SwapperRot = new Vector3(0,180,0);
				}

				Vector3 pos = new Vector3(posX,posY, 0);
			
				Instantiate (SwapperObject, pos, Quaternion.Euler(SwapperRot));
			}

			 
		}
}

	void Update ()
	{
		if (GemSpawned == true) 
		{
			SpawnGem ();
		}

	}

	void SpawnGem()
	{
		for (int s = 0; s < x; s++) 
		{
			if(s%2 == 0)
			{
				posX =s;
				posY = 11.5f;
			}
			else
			{
				posX = s;
				posY = 11f;
			}

			Vector3 pos = new Vector3(posX*offset/2, posY, 0);

			RaycastHit spawnGemhit;

			Physics.Raycast (pos, new Vector3 (0, -1, 0),out spawnGemhit, 2f);

			if (spawnGemhit.rigidbody != null)
			{

			}
			else
			{
				Instantiate(gemObject, new Vector3(posX*offset/2,posY - 1,0), Quaternion.identity );
			}
		}

	}



}

