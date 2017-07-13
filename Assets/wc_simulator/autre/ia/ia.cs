using UnityEngine;
using System.Collections;

public class ia : MonoBehaviour {


	enum etat_ia
	{
		attendre,
		courir,
		marcher
	}
	
	//propiétés:
	public int vitesse_max = 10;
	public int vitesse_min = 1;

	private int marche = 0;
	private int course =0;
	private int vitesse_courante = 0;

	private etat_ia etat_courant;


	// Use this for initialization
	void Start () 
	{
		marche = vitesse_min;
		vitesse_courante=marche;
		course = Random.Range(vitesse_min,vitesse_max);
		etat_courant=etat_ia.marcher;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(etat_courant)
		{
			case etat_ia.attendre:
				//change_etat(etat_ia.marcher);
				transform.Translate(Vector3.forward*Time.deltaTime*vitesse_courante);
			break;

			case etat_ia.courir:
				transform.Translate(Vector3.forward*Time.deltaTime*vitesse_courante);
			break;

			case etat_ia.marcher:
				//change_etat(etat_ia.attendre);
				transform.Translate(Vector3.forward*Time.deltaTime*vitesse_courante);
			break;
		}
	}

	void change_etat(etat_ia etat)
	{
		etat_courant=etat;
		print (etat_courant);
		switch(etat)
		{
			case etat_ia.attendre:
				vitesse_courante=0;
			break;

			case etat_ia.courir:
				vitesse_courante=course;
			break;

			case etat_ia.marcher:
				vitesse_courante=marche;
			break;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		transform.Rotate(Vector3.up*Time.deltaTime*1000);

		if(other.name=="immeuble1" || other.name=="immeuble2" || other.name=="immeuble3" || other.name=="Route" )
		{
			transform.Rotate(new Vector3(0,180,0));
		}
	}

	void OnCollisionEnter(Collision other)
	{
		print (other.collider.name);
	}

	void OnParticleCollision(GameObject other)
	{
		change_etat(etat_ia.courir);
		print ("onche");
	}
}
