using UnityEngine;
using System.Collections;

public class main_menu : MonoBehaviour 
{
	enum Menu_page
	{
		principal,
		credit,
		jeux
	}

	private int tailleX = 100;
	private int tailleY = 20;
	private Menu_page page = Menu_page.principal;
	public Font myFont;

	void Start()
	{
		Menu_page page = Menu_page.principal;
	}
	
	void OnGUI()
	{
		GUI.skin.font=myFont;

		if(page==Menu_page.principal){menu_principal();}
		else if(page == Menu_page.jeux){menu_jeux();}
		else if(page == Menu_page.credit){menu_credit();}
	}

	void menu_jeux()
	{

		GUI.Label (new Rect(Screen.width/2 -75,20,150,20),"CHOIX DU NIVEAUX");

		if(GUI.Button(new Rect(Screen.width/2 - 75,100,150,50),"Scène 1")){Application.LoadLevel(1);}
		if(GUI.Button(new Rect(Screen.width/2 - 75,155,150,50),"Scène 2")){Application.LoadLevel(2);}
		if(GUI.Button(new Rect(Screen.width/2 - 75,210,150,50),"Scène 3")){Application.LoadLevel(3);}


		if(Input.GetKey(KeyCode.Escape))
		{
			 page = Menu_page.principal;
		}
	}


	void menu_credit()
	{
		GUI.Label (new Rect(Screen.width/2 -50,20,100,20),"CREDIT");

		GUI.Label(new Rect(Screen.width/4,100,Screen.width - Screen.width/4,Screen.height-100),"Comme ce jeux est vraiment bidon, l'auteur a préféré ne pas dévoiler son identité. Merci de votre compréhension"); 


		if(Input.GetKeyUp(KeyCode.Escape))
		{
			 page = Menu_page.principal;
		}
	}


	void menu_principal()
	{
		
		if(GUI.Button(new Rect(Screen.width/2-tailleX/2, Screen.height/2 - 105,tailleX,tailleY),"JOUER"))
		{
			 page = Menu_page.jeux;
		}
		
		if(GUI.Button(new Rect(Screen.width/2-tailleX/2,Screen.height/2 - 55,tailleX,tailleY),"TEST"))
		{
			Application.LoadLevel(1);
		}
		
		
		if(GUI.Button(new Rect(Screen.width/2-tailleX/2 , Screen.height/2 ,tailleX,tailleY),"CREDIT"))
		{
			 page = Menu_page.credit;
		}
		
		if(GUI.Button(new Rect(Screen.width/2-tailleX/2, Screen.height/2 + 55,tailleX,tailleY),"QUITTER"))
		{
			Application.Quit();
		}
	}
}
