using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour 
{
	private GameObject gamescript = null;

	public GameObject pts_show;
	public float vitesse=1f;
	public float duration=1f;
	public float taille=1;

	private int pts=0;

	void Start()
	{
		gamescript = GameObject.Find("game");
		pts=0;
	}

	//filtre des points de collsion
	void OnParticleCollision(GameObject other) 
	{
		if(gamescript!=null)
		{
			switch(other.name)
			{

				case "TROU":
					gamescript.SendMessage("AddPoint",50);
					pts=50;
				break;

				case "PLAT":
					gamescript.SendMessage("AddPoint",-5);
					pts=-5;
				break;

				case "ARMATURE":
					gamescript.SendMessage("AddPoint",1);
					pts=1;
				break;

				case "CUVE":
					gamescript.SendMessage("AddPoint",25);
				break;

				case "CUVE1":
					gamescript.SendMessage("AddPoint",20);
					pts=20;
				break;

				case "CUVETTE":
					gamescript.SendMessage("AddPoint",10);
					pts=10;
				break;

				case "CUVE_EAU":
					gamescript.SendMessage("AddPoint",5);
					pts=5;
				break;

				case "BONUS":
					gamescript.SendMessage("AddPoint",25);
					pts=25;
				break;

				case "CIBLE":
					gamescript.SendMessage("AddPoint",25);
					pts=25;
				break;

				case "AUTRE":
					gamescript.SendMessage("AddPoint",-1);
					pts=-1;
				break;

				case "MALUS":
					gamescript.SendMessage("AddPoint",-10);
					pts=-10;
				break;

				case "Route":
					gamescript.SendMessage("AddPoint",-10);
					pts=-10;
				break;

				case "trottoir":
					gamescript.SendMessage("AddPoint",-1);
					pts=-1;
				break;

				case "RENAULT21_2":
					gamescript.SendMessage("AddPoint",40);
					pts=40;
				break;


				case "Personnage":
					gamescript.SendMessage("AddPoint",50);
					pts=50;
				break;

				default:
					gamescript.SendMessage("AddPoint",1);
					pts=1;
				break;

			}

			GameObject obj = Instantiate(pts_show,other.GetComponent<Collider>().transform.position,other.GetComponent<Collider>().transform.rotation) as GameObject;
			
			if(obj!=null)
			{
				string[] param = new string[4];
				param[0]=pts.ToString();
				param[1]=vitesse.ToString();
				param[2]=duration.ToString();
				param[3]=taille.ToString();
				
				obj.SendMessage("setup",param);
			}
		}
	}
}
