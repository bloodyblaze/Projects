using UnityEngine;
using System.Collections;

public class BuildingSpawner : MonoBehaviour
{
	public static bool destroyHologram = false;

	Transform CamTrans;
	Transform closestChild;
	Transform lastChild;


	Vector3 currentBuildobject;
	Vector3 lastBuildobject;
	Vector3 offset;
	Vector3 WallmidPoint;
	Vector3 Childone;
	Vector3 Childtwo;
	

	GameObject hologram;
	GameObject buildObject;

	public GameObject HologramFoundation, HologramFloor, HologramSteps,
	HologramWall, HologramDoorway, HologramLshapeStairs, HologramUshapeStairs;

	public GameObject Foundation, Floor, Steps, Wall, Doorway, LshapeStairs, UshapeStairs;


	float closestPos = 100f;

	public int objectType = 0;

	public RaycastHit hitinfo, hitHolo;

	void Start ()
	{

	}

	void Update ()
	{
		//resets closet Pos so that it checks every update
		closestPos = 100f;

		//Sets which object to place by number
		#region
		if(Input.GetKeyDown("1"))
		{
			objectType = 1;
		}
		if(Input.GetKeyDown("2"))
		{
			objectType = 2;
		}
		if(Input.GetKeyDown ("3"))
		{
			objectType = 3;
		}
		if(Input.GetKeyDown ("4"))
		{
			objectType = 4;
		}
		if(Input.GetKeyDown ("5"))
		{
			objectType = 5;
		}
		if(Input.GetKeyDown ("6"))
		{
			objectType = 6;
		}
		if(Input.GetKeyDown ("7"))
		{
			objectType = 7;
		}
		if(Input.GetKeyDown ("8"))
		{
			objectType = 8;
		}
		if(Input.GetKeyDown ("9"))
		{
			objectType = 9;
		}
		#endregion
		//Raycast from camera 10 meters out
		#region
		CamTrans = Camera.main.transform;
		Ray ray = new Ray (CamTrans.position, CamTrans.forward);
		Debug.DrawRay(CamTrans.position, CamTrans.forward, Color.red);
		Physics.Raycast (ray, out hitinfo, 10f);
		#endregion

		if (hitinfo.rigidbody != null)
		{
			if(hitinfo.collider.gameObject.CompareTag("Foundation"))
			{

				foreach(Transform child in hitinfo.transform)
				{
					if(Vector3.Distance (child.position, hitinfo.point) <closestPos)
					{
						closestPos = Vector3.Distance (child.position, hitinfo.point);
						closestChild = child;
					}
			    {
				if(closestChild != lastChild)
				{
					destroyHologram = true;

					lastChild = closestChild;

					if(objectType == 1)
					{
						Debug.Log ("foundation");

						if(lastChild.name == "SocketXplus")
						{
							offset = new Vector3(1.5f,-1.5f,0f);
						}
						if(lastChild.name == "SocketXneg")
						{
							offset = new Vector3(-1.5f,-1.5f,0f);
						}
						if(lastChild.name == "SocketZplus")
						{
							offset = new Vector3(0f,-1.5f,1.5f);
						}
						if(lastChild.name == "SocketZneg")
						{
							offset = new Vector3(0f,-1.5f,-1.5f);
						}

						Physics.Raycast(lastChild.position + offset + new Vector3(0f, 3f, 0), new Vector3(0, -1f, 0), out hitHolo);

						if (hitHolo.rigidbody == null)
						{
							hologram = HologramFoundation;
							
							buildObject = Foundation;

							currentBuildobject = lastChild.position + offset;
							
							Instantiate(hologram, currentBuildobject, Quaternion.identity);

						}

					}
					if(objectType == 2)
					{
						Debug.Log("Wall");

						if(lastChild.name == "SocketXplus")
						{
							offset = new Vector3(0,1.5f,0);
						}
						if(lastChild.name == "SocketXneg")
						{
							offset = new Vector3(0,1.5f,0);
						}
						if(lastChild.name == "SocketZplus")
						{
							offset = new Vector3(0,1.5f,0);
						}
						if(lastChild.name == "SocketZneg")
						{
							offset = new Vector3(0,1.5f,0);
						}

						Debug.DrawRay (lastChild.position, new Vector3(0,1f,0), Color.red, 10f);

						Physics.Raycast(lastChild.position, new Vector3(0,1f,0), out hitHolo, 10f);


						if (hitHolo.rigidbody == null)
						{

							hologram = HologramWall;
							buildObject = Wall;

							currentBuildobject = lastChild.position + offset;

							Instantiate (hologram, currentBuildobject, lastChild.rotation);
						}

						
					}
					if(objectType == 3)
					{

						Debug.Log("floor");

						foreach(Transform child in hitinfo.transform)
						{
							if(Vector3.Distance (child.position, hitinfo.point) <closestPos)
							{
								closestPos = Vector3.Distance (child.position, hitinfo.point);
								closestChild = child;
							}
						}
						
					}

				}

				if(Input.GetMouseButtonDown (0) == true)
				{


						if (hitHolo.rigidbody == null)
						{
							if(currentBuildobject != lastBuildobject)
						    {
								lastBuildobject = currentBuildobject;
								Instantiate(buildObject,currentBuildobject, lastChild.rotation);
								destroyHologram = true;
						    }

						}
				}
			}

			if(hitinfo.collider.gameObject.CompareTag("Wall"))
			{
				foreach(Transform child in hitinfo.transform)
				{
					if(child.name == "SocketXplus")
					{
						Childone = child.position;
					}
					if(child.name == "SocketXneg")
					{
						Childtwo = child.position;
					}

					WallmidPoint = new Vector3 ((Childone.x + Childtwo.x)/2.0f,(Childone.y + Childtwo.y)/2.0f +1.5f,(Childone.z + Childtwo.z)/2.0f);


					if(Vector3.Distance (child.position, hitinfo.point) <closestPos)
					{
						closestPos = Vector3.Distance (child.position, hitinfo.point);
						closestChild = child;
					}


					
					if(closestChild != lastChild)
					{
						lastChild = closestChild;

						destroyHologram = true;


						
						
						if(objectType == 0)
						{
							
							Debug.Log ("no object selected");
							
						}
						if(objectType == 2)
						{
							Debug.Log("Wall");
							
							if(lastChild.name == "SocketXplus")
							{
							}
							if(lastChild.name == "SocketXneg")
							{
							}



							Physics.Raycast(lastChild.position + offset,new Vector3(0,1,0), out hitHolo, 1f);
							
							
							if (hitHolo.rigidbody == null)
							{
								
								hologram = HologramWall;
								buildObject = Wall;


								
								currentBuildobject = WallmidPoint;
								
								Instantiate (hologram, currentBuildobject, lastChild.rotation);
							}
							
							
						}
						if(objectType == 3)
						{
							
							Debug.Log("floor");
							
							if(lastChild.name == "SocketXplus")
							{
								offset = new Vector3(-1.375f,0,0);
							}
							if(lastChild.name == "SocketXneg")
							{
								offset = new Vector3(1.375f,0,0);
							}
							
							Physics.Raycast(lastChild.position + offset,new Vector3(0,1,0), out hitHolo, 1f);
							
							
							if (hitHolo.rigidbody == null)
							{
								
								hologram = HologramFloor;
								buildObject = Floor;
								
								currentBuildobject = lastChild.position + offset;
								
								Instantiate (hologram, currentBuildobject, lastChild.rotation);
							}
							
						}
						
					}
					
					if(Input.GetMouseButtonDown (0) == true)
					{
						
						
						if (hitHolo.rigidbody == null)
						{
							if(currentBuildobject != lastBuildobject)
							{
								lastBuildobject = currentBuildobject;
								Instantiate(buildObject,currentBuildobject, lastChild.rotation);
								destroyHologram = true;
							}
							
						}
					}
				}
				
			}
			
			if(hitinfo.collider.gameObject.CompareTag ("Floor"))					
			{
						foreach(Transform child in hitinfo.transform)
						{
							if(Vector3.Distance (child.position, hitinfo.point) <closestPos)
							{
								closestPos = Vector3.Distance (child.position, hitinfo.point);
								closestChild = child;
							}
						{
								if(closestChild != lastChild)
								{
									destroyHologram = true;
									
									lastChild = closestChild;
									
									if(objectType == 1)
									{
										Debug.Log ("foundation");
										
										if(lastChild.name == "SocketXplus")
										{
											offset = new Vector3(1.5f,-1.5f,0f);
										}
										if(lastChild.name == "SocketXneg")
										{
											offset = new Vector3(-1.5f,-1.5f,0f);
										}
										if(lastChild.name == "SocketZplus")
										{
											offset = new Vector3(0f,-1.5f,1.5f);
										}
										if(lastChild.name == "SocketZneg")
										{
											offset = new Vector3(0f,-1.5f,-1.5f);
										}
										
										Physics.Raycast(lastChild.position + offset + new Vector3(0f, 3f, 0), new Vector3(0, -1f, 0), out hitHolo);
										
										if (hitHolo.rigidbody == null)
										{
											hologram = HologramFoundation;
											
											buildObject = Foundation;
											
											currentBuildobject = lastChild.position + offset;
											
											Instantiate(hologram, currentBuildobject, Quaternion.identity);
											
										}
										
									}
									if(objectType == 2)
									{
										Debug.Log("Wall");
										
										if(lastChild.name == "SocketXplus")
										{
											offset = new Vector3(0,1.5f,0);
										}
										if(lastChild.name == "SocketXneg")
										{
											offset = new Vector3(0,1.5f,0);
										}
										if(lastChild.name == "SocketZplus")
										{
											offset = new Vector3(0,1.5f,0);
										}
										if(lastChild.name == "SocketZneg")
										{
											offset = new Vector3(0,1.5f,0);
										}
										
										Debug.DrawRay (lastChild.position, new Vector3(0,1f,0), Color.red, 10f);
										
										Physics.Raycast(lastChild.position, new Vector3(0,1f,0), out hitHolo, 10f);
										
										
										if (hitHolo.rigidbody == null)
										{
											
											hologram = HologramWall;
											buildObject = Wall;
											
											currentBuildobject = lastChild.position + offset;
											
											Instantiate (hologram, currentBuildobject, lastChild.rotation);
										}
										
										
									}
									if(objectType == 3)
									{
										
										Debug.Log("floor");
										
										foreach(Transform child in hitinfo.transform)
										{
											if(Vector3.Distance (child.position, hitinfo.point) <closestPos)
											{
												closestPos = Vector3.Distance (child.position, hitinfo.point);
												closestChild = child;
											}
										}
										
									}
									
								}
								
								if(Input.GetMouseButtonDown (0) == true)
								{
									
									
									if (hitHolo.rigidbody == null)
									{
										if(currentBuildobject != lastBuildobject)
										{
											lastBuildobject = currentBuildobject;
											Instantiate(buildObject,currentBuildobject, lastChild.rotation);
											destroyHologram = true;
										}
										
									}
								}
								
							}
							
						}
						
						else
						{
							destroyHologram = true;
						}
						
					}
				}
				