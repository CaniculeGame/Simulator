using UnityEngine;
using System.Collections;

public class gui_power_script : MonoBehaviour 
{
	public GameObject powerBarMax;
	public GameObject mybar;
	private GameObject barInstantiate;
	private GameObject powerBarMaxbarInstantiate;
	
	private int puissance=0;
	private int puissance_max=100;
	private int barWidth=0;
	private int barHeight=0;


	// Use this for initialization
	void Start () 
	{
		puissance=0;
		barWidth=32;
		barHeight=128;
		barInstantiate = Instantiate(mybar,transform.position,transform.rotation) as GameObject;
		powerBarMaxbarInstantiate = Instantiate(powerBarMax,transform.position,transform.rotation) as GameObject;
	}

	void Update()
	{
		barInstantiate.transform.position=Camera.main.WorldToScreenPoint(transform.position);
		barInstantiate.transform.localScale=Vector3.zero;

		powerBarMaxbarInstantiate.transform.position=Camera.main.WorldToViewportPoint(transform.position);
		powerBarMaxbarInstantiate.transform.localScale=Vector3.zero;

		barHeight=puissance;
		barInstantiate.GetComponent<GUITexture>().pixelInset=new Rect(0,0,32,barHeight);
	}

	void power(int pwd)
	{
		puissance=pwd;
	}
}
