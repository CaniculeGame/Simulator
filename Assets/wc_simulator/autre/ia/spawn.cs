using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

	public int max_entite = 100;
	public int espace_min =0;
	public int espace_max =2;
	public GameObject bonhomme;

	static private int compteur = 0;

	private float tps_av =0;
	private float tps_Actu =0;
	private float tps_courant =0;

	// Use this for initialization
	void Start () 
	{
		compteur = 0;
		tps_av =0;
		tps_Actu =0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		tps_courant=Time.time;
		if(tps_courant-tps_av>espace_max)
		{
			Instantiate(bonhomme,transform.position,transform.rotation);
			compteur++;
			tps_av=tps_courant;
		}
	}


}
