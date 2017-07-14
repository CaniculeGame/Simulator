using UnityEngine;
using System.Collections;

public class ia_voiture : MonoBehaviour {

    int vie = 100;
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Translate(Vector3.back);
	}

	void OnCollisionEnter(Collision other)
	{
       // print(other.gameObject.name);
	}

    void OnTriggerEnter(Collider other)
    {
        // print(other.gameObject.name);
    }
}
