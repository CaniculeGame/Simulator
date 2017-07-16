using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System;

public class main_menu : MonoBehaviour
{
    public GUISkin skin;
    public int langue = 1;// 1 = fr 0= en

    private int size;

    enum Menu_page
    {
        principal,
        credit,
        jeux,
        pub,
        stat
    }

    enum EthnieEnum
    {
        caucase = 0,
        asia = 1,
        noir = 2,
        femme = 3
    }
    EthnieEnum ethnie = EthnieEnum.caucase;

    private int tailleX = 30 * Screen.width / 100;
    private int tailleY = 10 * Screen.height / 100;
    private Menu_page page = Menu_page.pub;
    public Font myFont;
    public int TimeWait = 5;

    void Start()
    {
        page = Menu_page.pub;
        DictionnaireLang lg = DictionnaireLang.Instance;
        DictionnaireLang.Instance.Init();

        string lgStr = PlayerPrefs.GetString("lg");

        if (lgStr != "")
        {
            DictionnaireLang.Instance.Load("DictionnaireLangue/language", lgStr);
            if (lgStr == "fr")
                langue = 1;
            else
                langue = 0;
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.French)
            {
                DictionnaireLang.Instance.Load("DictionnaireLangue/language", "fr");
                langue = 1;
            }
            else
            {
                DictionnaireLang.Instance.Load("DictionnaireLangue/language", "en");
                langue = 0;
            }
        }

        int e = PlayerPrefs.GetInt("ethint", 0);
        switch (e)
        {
            case 0:
                ethnie = EthnieEnum.caucase;
                break;

            case 1:
                ethnie = EthnieEnum.asia;
                break;

            case 2:
                ethnie = EthnieEnum.noir;
                break;

            case 3:
                ethnie = EthnieEnum.femme;
                break;

            default:
                ethnie = EthnieEnum.caucase;
                break;
        }


    }

    void OnGUI()
    {
        GUI.skin = skin;

        if (Screen.width >= 1900)
            size = 36;
        else if (Screen.width >= 1366 && Screen.width < 1024)
            size = 30;
        else
            size = 24;

        GUI.skin.label.fontSize = size;
        GUI.skin.button.fontSize = size;
        GUI.skin.toggle.fontSize = size;
        GUI.skin.font = myFont;


        if (page == Menu_page.principal) { menu_principal(); }
        else if (page == Menu_page.jeux) { menu_jeux(); }
        else if (page == Menu_page.credit) { menu_credit(); }
        else if (page == Menu_page.pub) { menu_pub(); }
        else if (page == Menu_page.stat) { menu_stat(); }
    }

    private void menu_stat()
    {
        GUI.Label(new Rect(45 * Screen.width / 100, 5 * Screen.height / 100, 20 * Screen.width / 100, 10 * Screen.height / 100), DictionnaireLang.Instance.getValue("stats"));

        GUI.Label(new Rect(20 * Screen.width / 100, 20 * Screen.height / 100, 60 * Screen.width / 100, 80 * Screen.height / 100), DictionnaireLang.Instance.getValue("textStat"));

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            page = Menu_page.principal;
        }

        if (GUI.Button(new Rect(40 * Screen.width / 100, 80 * Screen.height / 100, 20 * Screen.width / 100, 10 * Screen.height / 100), DictionnaireLang.Instance.getValue("quitter_vers_menu")))
            page = Menu_page.principal;
    }

    void menu_jeux()
    {

        GUI.Label(new Rect(35 * Screen.width, 20, 150, 20), DictionnaireLang.Instance.getValue("choix_lvl"));

        if (GUI.Button(new Rect(35 * Screen.width / 100, 25 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("lvl1")))
        { SceneManager.LoadScene(1); }
        if (GUI.Button(new Rect(35 * Screen.width / 100, 40 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("lvl2")))
        { SceneManager.LoadScene(2); }
        if (GUI.Button(new Rect(35 * Screen.width / 100, 55 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("lvl3")))
        { SceneManager.LoadScene(3); }


        if (Input.GetKey(KeyCode.Escape))
        {
            page = Menu_page.principal;
        }
    }


    void menu_credit()
    {
        GUI.Label(new Rect(45 * Screen.width / 100, 5 * Screen.height / 100, 20 * Screen.width / 100, 10 * Screen.height / 100), DictionnaireLang.Instance.getValue("credit"));

        GUI.Label(new Rect(20 * Screen.width / 100, 20 * Screen.height / 100, 60 * Screen.width / 100, 80 * Screen.height / 100), DictionnaireLang.Instance.getValue("textCredit"));

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            page = Menu_page.principal;
        }

        if (GUI.Button(new Rect(40 * Screen.width / 100, 80 * Screen.height / 100, 20 * Screen.width / 100, 10 * Screen.height / 100), DictionnaireLang.Instance.getValue("quitter_vers_menu")))
            page = Menu_page.principal;
    }

    void menu_pub()
    {
        Debug.Log("menu_pub");
        /* if (Advertisement.IsReady())
         {
             Debug.Log("pub");
             var options = new ShowOptions { resultCallback = HandleShowResult };
             Advertisement.Show(options);
         }
         else
         {
             if(TimeWait <= Time.time)*/
        page = Menu_page.principal;
        //  }
    }

    /*   private void HandleShowResult(ShowResult result)
       {
           page = Menu_page.principal;
       }*/


    void menu_principal()
    {

        if (GUI.Button(new Rect(35 * Screen.width / 100, 25 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("jouer")))
        {
            page = Menu_page.jeux;
        }

        if (GUI.Button(new Rect(35 * Screen.width / 100, 40 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("stats")))
        {
            page = Menu_page.stat;
        }


        if (GUI.Button(new Rect(35 * Screen.width / 100, 55 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("credit")))
        {
            page = Menu_page.credit;
        }

        if (GUI.Button(new Rect(35 * Screen.width / 100, 70 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("quitter")))
        {
            Application.Quit();
        }

        GUI.Label(new Rect(20 * Screen.width / 100, 90 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("ethnie"));
        if (GUI.Button(new Rect(35 * Screen.width / 100, 90 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue(ethnie.ToString()),skin.customStyles[1]))
        {
            switch (ethnie)
            {
                case EthnieEnum.asia:
                    ethnie = EthnieEnum.caucase;
                    break;

                case EthnieEnum.caucase:
                    ethnie = EthnieEnum.noir;
                    break;

                case EthnieEnum.noir:
                    ethnie = EthnieEnum.femme;
                    break;

                case EthnieEnum.femme:
                    ethnie = EthnieEnum.asia;
                    break;
            }

            PlayerPrefs.SetString("eth", ethnie.ToString());
            PlayerPrefs.SetInt("ethint", (int)ethnie);
            PlayerPrefs.Save();
        }



        GUI.Label(new Rect(65 * Screen.width / 100, 90 * Screen.height / 100, 13 * Screen.width / 100, tailleY), DictionnaireLang.Instance.getValue("languageChoix"));
        if (GUI.Button(new Rect(80 * Screen.width / 100, 90 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("langue"), skin.customStyles[1]))
        {
            if (langue == 1)
            { langue = 0;
                DictionnaireLang.Instance.ReLoad("DictionnaireLangue/language", "en"); }

            else
            { langue = 1;
                DictionnaireLang.Instance.ReLoad("DictionnaireLangue/language", "fr"); }

            PlayerPrefs.SetString("lg", DictionnaireLang.Instance.getLangue());
            PlayerPrefs.Save();
        }


    }
}
