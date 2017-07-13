using UnityEngine;
using System.Collections;

public class ia_voiture : MonoBehaviour {


	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Translate(Vector3.back);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag == "voiture")
		{
			print ("hap");
		}
		else
		{
			print ("onche");
		}
	}
}
