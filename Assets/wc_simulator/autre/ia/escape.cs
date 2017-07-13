using UnityEngine;
using System.Collections;


public class escape : MonoBehaviour 
{
	public Transform pos;

	void OnTriggerEnter(Collider other)
	{

		if(other.GetComponent<Collider>().name=="Personnage")
		{	Destroy(other.gameObject);}
		else
		{
			other.transform.position=pos.position;
		}
	}
}
