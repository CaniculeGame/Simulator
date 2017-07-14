using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class main_menu : MonoBehaviour
{
    public GUISkin skin;
    public bool langue = false;// 1 = fr 0= en

    enum Menu_page
    {
        principal,
        credit,
        jeux,
        pub
    }

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

        if (Application.systemLanguage == SystemLanguage.French)
        {
            DictionnaireLang.Instance.Load("DictionnaireLangue/language", "fr");
            langue = true;
        }
        else
        {
            DictionnaireLang.Instance.Load("DictionnaireLangue/language", "en");
            langue = false;
        }


    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.skin.label.fontSize = 36;
        GUI.skin.button.fontSize = 36;
        GUI.skin.toggle.fontSize = 36;
        GUI.skin.font = myFont;


        if (page == Menu_page.principal) { menu_principal(); }
        else if (page == Menu_page.jeux) { menu_jeux(); }
        else if (page == Menu_page.credit) { menu_credit(); }
        else if (page == Menu_page.pub) { menu_pub(); }
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

        if (GUI.Button(new Rect(35 * Screen.width / 100, 40 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("test")))
        {
            SceneManager.LoadScene(1);
        }


        if (GUI.Button(new Rect(35 * Screen.width / 100, 55 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("credit")))
        {
            page = Menu_page.credit;
        }

        if (GUI.Button(new Rect(35 * Screen.width / 100, 70 * Screen.height / 100, tailleX, tailleY), DictionnaireLang.Instance.getValue("quitter")))
        {
            Application.Quit();
        }


        langue = GUI.Toggle(new Rect(70 * Screen.width / 100, 90 * Screen.height / 100, tailleX, tailleY), langue, DictionnaireLang.Instance.getValue("langue"));
        if (langue && DictionnaireLang.Instance.getLangue() != "fr")
            DictionnaireLang.Instance.ReLoad("DictionnaireLangue/language", "fr");
        else if (!langue && DictionnaireLang.Instance.getLangue() != "en")
            DictionnaireLang.Instance.ReLoad("DictionnaireLangue/language", "en");


    }
}
