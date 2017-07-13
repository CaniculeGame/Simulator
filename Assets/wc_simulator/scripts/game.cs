using UnityEngine;
using System.Collections;

enum Etat
{
	Start,
	Pause,
	Game,
	End
}


public class game : MonoBehaviour 
{
	//variable détat
	private Etat etat_courant;
	private bool enPause = false;

	//variables gameplay
	private int score = 0;
	private int jauge_min = 0;
	private int jauge = 100;
	private int jauge_max = 100;
	private int capacite_vessie_max = 600;
	private int capacite_vessie = 600;
	private float temps =0;

	
	//score  à viser pour avoir les étoiles
	public int score1 = 0;
	public int score2 = 0;
	public int score3 = 0;

	public Font myFont;

	public GameObject player;
	private controller scriptControlle;


	//initilisation de la partie
	void Start () 
	{
		score = 0;
		temps = 0;
		jauge_min = 0;
		jauge_max = 100;
		jauge = jauge_max;
		capacite_vessie_max = 600;
		capacite_vessie = capacite_vessie_max;
		etat_courant=Etat.Start;
		enPause = false;
		scriptControlle = player.GetComponentInChildren<controller>();
		scriptControlle.enabled = false;
		//scriptControlle.gameObject.GetComponent<Animator>().enabled=true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			mettrePause();
		}


		switch(etat_courant)
		{
			case Etat.Start:
				debut();
			break;
				
			/*case Etat.Pause:
				pause();
			break;*/
				
			case Etat.Game:
				jouer();
			break;
				
			case Etat.End:
				fin();
			break;
		}
	}

	//fonction de presentation du niveau (camera + phrase introduction)
	void debut()
	{
		change_etat(Etat.Game);
	}

	//fonction avec recapitulatif score + diverses option
	void fin(){}

	//le jeux
	void jouer()
	{
		temps += Time.deltaTime;

		if(jauge<=jauge_min)
		{
			change_etat(Etat.End);
		}
	}

	// lorsqu'on est en pause , affichage de divers boutton //traité dans 
/*	void pause()
	{
		
	}*/

	//lors d'un appuye sur la touche pause on change d'état + mise à jour variable
	void mettrePause()
	{
		enPause=!enPause;
		if(enPause == true){change_etat(Etat.Pause);}
		else{change_etat(Etat.Game);}
	}


	//mise à jour de la machine à etat
	void change_etat(Etat etat_voulu)
	{
		etat_courant=etat_voulu;
		switch(etat_courant)
		{
			case Etat.Start:
			break;
				
			case Etat.Pause:
				Time.timeScale=0;
				scriptControlle.enabled = false;
				enPause=true;
			break;
				
			case Etat.Game:
				enPause=false;
				Time.timeScale=1;
				scriptControlle.enabled = true;
			break;
				
			case Etat.End:
				//Time.timeScale=0;
				scriptControlle.SendMessage("end_jet");
				scriptControlle.enabled = false;
				Destroy(scriptControlle.gameObject.GetComponent<Animator>());
			break;
		}
	}

	void AddPoint(int pts)
	{
		score+=pts;
		Vessie();
	}
	
	void Vessie()
	{
		capacite_vessie--;
		MajJauge();
	}

	void MajJauge()
	{
		jauge=(jauge_max*capacite_vessie)/capacite_vessie_max;
		if(jauge<=0){jauge=0;}
	}

	void OnGUI()
	{
		GUI.skin.font=myFont;

		if(etat_courant != Etat.End)
		{
			GUI.Label (new Rect (0,0,100,50), "Score "+score+" pts");
			GUI.Label (new Rect (0,50,100,50), "Vessie "+jauge+"%");
			GUI.Label (new Rect (Screen.width/2-100/2,0,100,50), ""+Mathf.Round(temps)+" sec");

			if(enPause)
			{
				GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
				GUI.Label(new Rect(Screen.width/2-50/2,Screen.height/2-110,100,50),"PAUSE");
				if(GUI.Button(new Rect(Screen.width/2-150/2,Screen.height/2-55,150,50),"Reprendre"))
				{change_etat(Etat.Game);}
				if(GUI.Button(new Rect(Screen.width/2-150/2,Screen.height/2,150,50),"Recommencer"))
				{Application.LoadLevel(Application.loadedLevel);}
				if(GUI.Button(new Rect(Screen.width/2-150/2,Screen.height/2+55,150,50),"Quitter"))
				{Application.LoadLevel(0);}
			}
		}
		else if (etat_courant == Etat.End)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"Comme j'ai la flemme d'enregitrer le score, on vas dire que t'as perdu. NO RAGE LE PUCIX!!!");
			GUI.Label(new Rect(Screen.width/2-150/2,Screen.height/2-110,150,50),"Score "+score+" pts");
			GUI.Label(new Rect(Screen.width/2-150/2,Screen.height/2-55,150,50),""+Mathf.Round(temps)+" sec");
			if(GUI.Button(new Rect(Screen.width/2-150/2,Screen.height/2,150,50),"Recommencer"))
			{Application.LoadLevel(Application.loadedLevel);}
			if(GUI.Button(new Rect(Screen.width/2-150/2,Screen.height/2+55,150,50),"Quitter"))
			{	Application.LoadLevel(0);}
		}
	}
}
