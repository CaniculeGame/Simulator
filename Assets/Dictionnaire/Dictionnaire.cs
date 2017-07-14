using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DictionnaireLang
{

    private static DictionnaireLang instance_ = null;
    private Dictionary<string, string> dictionnaire_;
    private string langue_ = "fr";

    public static DictionnaireLang Instance
    {
        get
        {
            if (instance_ == null)
                instance_ = new DictionnaireLang();


            return instance_;
        }
    }


    public void Load(string file, string langue)
    {

        if (langue == null || langue == "")
        {
            Debug.LogError("Erreur: language invalide");
            return;
        }

        langue_ = langue;
        try
        {
            if (dictionnaire_ == null)
                dictionnaire_ = new Dictionary<string, string>();

            //open file en fct de la paltforme cible
            //if (Application.platform == RuntimePlatform.Android)
            //{
            TextAsset txtTmp = (TextAsset)Resources.Load(file);
            if (txtTmp != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(txtTmp.text);
                /*}
                else
                {
                    doc.Load(xmlPath);
                }*/

                //si ouverture reussi alors 
                if (doc != null)
                {
                    //on recupere tous les noeuds
                    XmlNodeList list = doc.GetElementsByTagName("valeur");
                    //on parcours chaque noeud "valeur" (= pour chaque valeur faire)
                    foreach (XmlNode element in list)
                    {
                        //recuperation des noeuds enfant (=langue)
                        XmlNodeList child = element.ChildNodes;

                        foreach (XmlNode valeur in child) // pour chaque langue faire
                        {
                            //chaque ellement a plusieurs attribut. Il faut prendre le bon en fct de la langue choisie
                            if (valeur.Name == langue) // si on a la bonne langue on enregistre ds le dico
                            {
                                try
                                {
                                    dictionnaire_.Add(element.Attributes["name"].Value, valeur.InnerText);
                                }
                                catch (Exception e)
                                {
                                    Debug.Log("Attention clé deja existante dans le dictionnaire  " + element.Attributes["name"].Value + "  " + e);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Erreur : Fail initialisation, le fichier n'est pas trouvé chemin= " + file);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Erreur : chargement du fichier de langue echoué!! chemin= " + file + "  " + e);
        }

    }



    public string getLangue() { return langue_; }

    public void ReLoad(string file, string langue)
    {
        if (langue == null || langue == "")
        {
            Debug.LogError("Erreur: language invalide");
            return;
        }

        langue_ = langue;

        try
        {
            if (dictionnaire_ == null)
                dictionnaire_ = new Dictionary<string, string>();
            else
                dictionnaire_.Clear();

            //open file en fct de la paltforme cible
            //if (Application.platform == RuntimePlatform.Android)
            //{
            TextAsset txtTmp = (TextAsset)Resources.Load(file);
            if (txtTmp != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(txtTmp.text);

                //si ouverture reussi alors 
                if (doc != null)
                {
                    //on recupere tous les noeuds
                    XmlNodeList list = doc.GetElementsByTagName("valeur");
                    //on parcours chaque noeud "valeur" (= pour chaque valeur faire)
                    foreach (XmlNode element in list)
                    {
                        //recuperation des noeuds enfant (=langue)
                        XmlNodeList child = element.ChildNodes;

                        foreach (XmlNode valeur in child) // pour chaque langue faire
                        {
                            //chaque ellement a plusieurs attribut. Il faut prendre le bon en fct de la langue choisie
                            if (valeur.Name == langue) // si on a la bonne langue on enregistre ds le dico
                            {
                                try
                                {
                                    dictionnaire_.Add(element.Attributes["name"].Value, valeur.InnerText);
                                }
                                catch (Exception e)
                                {
                                    Debug.Log("Attention clé deja existante dans le dictionnaire  " + element.Attributes["name"].Value + "  " + e);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Erreur : Fail initialisation, le fichier n'est pas trouvé chemin= " + file);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Erreur : chargement du fichier de langue echoué!! chemin= " + file + "  " + e);
        }
    }

    public void Init()
    {
        dictionnaire_ = new Dictionary<string, string>();
    }



    public string getValue(string key)
    {
        bool res = false;
        string val = "";

        if (dictionnaire_ != null)
        {
            res = dictionnaire_.TryGetValue(key, out val);
        }

        if (res)
            return val;
        else
            return "error langue";
    }
}

