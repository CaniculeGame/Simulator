using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]

public class show_point : MonoBehaviour 
{
	// private variables:
	Vector3 crds_delta;
	float alpha;
	float life_loss;
	Camera cam;
		
	private Color color = Color.white;
		
	public void setup(string[] parametre)
	{
		GetComponent<TextMesh>().text = parametre[0];
		GetComponent<TextMesh>().characterSize = float.Parse(parametre[3]);
		life_loss = 1f / float.Parse(parametre[2]);
		crds_delta = new Vector3(0f, float.Parse(parametre[1]), 0f);



		if(float.Parse(parametre[0])>0)
		{GetComponent<TextMesh>().color = Color.green;}
		else
		{GetComponent<TextMesh>().color = Color.red;}
	}
		
	void Start() // some default values. You still need to call "setup"
	{
		alpha = 1f;
		cam = Camera.main;
		//crds_delta = new Vector3(0f, 1f, 0f);
		//life_loss = 0.5f;
	}
		
	void Update ()
	{
		// move upwards :
		transform.Translate(crds_delta * Time.deltaTime, Space.World);
			
		// change alpha :
		alpha -= Time.deltaTime * life_loss;
		GetComponent<Renderer>().material.color = new Color(color.r,color.g,color.b,alpha);
			
		// if completely faded out, die:
		if (alpha <= 0f) Destroy(gameObject);
			
		// make it face the camera:
		transform.LookAt(cam.transform.position);
		transform.rotation = cam.transform.rotation;
	}
}