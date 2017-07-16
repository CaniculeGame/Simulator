using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    public  int capacite_vessie_max = 1600;
	public  int capacite_vessie = 1600;
	private float temps =0;
    private int numTextScore = 1;

	
	//score  à viser pour avoir les étoiles
	public int score1 = 0;
	public int score2 = 0;
	public int score3 = 0;

	public Font myFont;

	public GameObject player;
	public controller scriptControlle;


	//initilisation de la partie
	void Start () 
	{
		score = 0;
		temps = 0;
		jauge_min = 0;
		jauge_max = 100;
		jauge = jauge_max;
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
              //  Debug.Log("start");
                break;
				
			case Etat.Pause:
               // Debug.Log("pause");
                Time.timeScale=0;
				scriptControlle.enabled = false;
				enPause=true;
			break;
				
			case Etat.Game:
               // Debug.Log("game");
				enPause=false;
				Time.timeScale=1;
				scriptControlle.enabled = true;
			break;
				
			case Etat.End:
               // Debug.Log("end");
                //Time.timeScale=0;
                if (scriptControlle != null)
				    scriptControlle.SendMessage("end_jet");
				scriptControlle.enabled = false;
				Destroy(scriptControlle.gameObject.GetComponent<Animator>());
                numTextScore = Random.Range(0, 5);

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
        GUI.skin.label.fontSize = 36;
        GUI.skin.button.fontSize = 36;
        GUI.skin.font=myFont;

		if(etat_courant != Etat.End)
		{
			GUI.Label (new Rect (2 * Screen.width / 100, 2 * Screen.height / 100 , 20 * Screen.width/100,5*Screen.height/100), DictionnaireLang.Instance.getValue("score") + " "+score+" "+ DictionnaireLang.Instance.getValue("pts"));
			GUI.Label (new Rect (2 * Screen.width / 100, 8 * Screen.height / 100, 40 * Screen.width / 100, 5 * Screen.height / 100), DictionnaireLang.Instance.getValue("vessie")+" " +jauge+"%");
			GUI.Label (new Rect (40 * Screen.width / 100, 2 * Screen.height / 100, 20 * Screen.width / 100, 5 * Screen.height / 100), ""+Mathf.Round(temps)+" "+ DictionnaireLang.Instance.getValue("sec"));

			if(enPause)
			{
				GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
				GUI.Label(new Rect(40 * Screen.width / 100, 20 * Screen.height / 100, 20 * Screen.width / 100, 10 * Screen.height / 100), DictionnaireLang.Instance.getValue("pause"));


				if(GUI.Button(new Rect(40 * Screen.width/ 100, 30 *Screen.height/100,20 * Screen.width / 100, 10 * Screen.height / 100), DictionnaireLang.Instance.getValue("continuer")))
				{change_etat(Etat.Game);}

				if(GUI.Button(new Rect(40 * Screen.width/100, 45 * Screen.height/100, 20 * Screen.width / 100, 10 * Screen.height / 100), DictionnaireLang.Instance.getValue("recommencer")))
				{ SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

				if(GUI.Button(new Rect(40 * Screen.width / 100, 60 * Screen.height / 100, 20 * Screen.width / 100, 10 * Screen.height / 100), DictionnaireLang.Instance.getValue("quitter")))
				{ SceneManager.LoadScene(0); ; }
			}
		}
		else if (etat_courant == Etat.End)
		{
            GUI.Box(new Rect(0, 0 * Screen.height / 100, Screen.width, Screen.height),DictionnaireLang.Instance.getValue("resultat"));

            GUI.Label(new Rect(0, 5 * Screen.height / 100, Screen.width, Screen.height), DictionnaireLang.Instance.getValue("defaite"+ numTextScore.ToString()));
            GUI.Label(new Rect(40 * Screen.width / 100, 30 * Screen.height / 100, 30 * Screen.width / 100, 10 * Screen.height / 100), DictionnaireLang.Instance.getValue("score") + " " + score + " " + DictionnaireLang.Instance.getValue("pts"));

			GUI.Label(new Rect(40 * Screen.width / 100, 45 * Screen.height / 100, 30 * Screen.width / 100, 10 * Screen.height / 100)," "+Mathf.Round(temps)+" "+ DictionnaireLang.Instance.getValue("sec"));
			if(GUI.Button(new Rect(40 * Screen.width / 100, 60 * Screen.height / 100, 30 * Screen.width / 100, 10 * Screen.height / 100), DictionnaireLang.Instance.getValue("recommencer")))
			{SceneManager.LoadScene(SceneManager.GetActiveScene().name);}
			if(GUI.Button(new Rect(40 * Screen.width / 100, 75 * Screen.height / 100, 30 * Screen.width / 100, 10 * Screen.height / 100),DictionnaireLang.Instance.getValue("quitter")))
			{	SceneManager.LoadScene(0);}
		}
	}
}
