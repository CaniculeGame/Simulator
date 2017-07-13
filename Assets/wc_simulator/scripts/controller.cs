using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour 
{
	private int positionXmax=50;
	private int positionXmin=0;
	private int positionYmax=Screen.width;
	private int positionYmin=0;

	private float puissance_min = 0;
	private float puissance_max = 5;
	private float puissance = 0;
	private float pas = 0.1f;
	private Vector3 position;
	public ParticleSystem particle;

	private float max_speed= 0;
	private float max_rate= 80;

	//Variable de controles
	private GameObject ctrl;

	public enum RotationAxes { MouseXAndY = 0 }
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityX = 15F;
	public float sensitivityZ = 15F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumZ = -60F;
	public float maximumZ = 60F;

	private float rotationX = 0F;
	private float rotationZ = 0F;

	public GUISkin skin;

	// Use this for initialization
	void Start () 
	{
		rotationX = 0F;
		rotationZ = 0F;

		puissance =0;
		puissance_max=5;
		puissance_min=0;
		pas = 0.1f;
		max_speed= puissance_max;
		max_rate= 80;

		ctrl = GameObject.FindGameObjectWithTag("GameController");

		particle.startSpeed=puissance;
		particle.emissionRate=0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		controle();
	}

	void end_jet()
	{
		particle.startSpeed=0;
		particle.emissionRate=0;
		particle.loop=false;
	}

	//controle du sexe
	void controle()
	{
		//mouvement doite/gauche, haut/bas 
	/*	if (axes == RotationAxes.MouseXAndY && !test_position(Input.GetTouch(0).position))
		{
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
			
			rotationZ += Input.GetAxis("Mouse Y") * sensitivityZ;
			rotationZ = Mathf.Clamp (rotationZ, minimumZ, maximumZ);
			
			ctrl.transform.localEulerAngles = new Vector3(-rotationZ, 0, -rotationX);
		}*/


		//gestion de la puissance des particules
		float y =0;
		float x =0;

			if(puissance< puissance_max)
			{	
				y=(puissance*100)/max_speed; 
				particle.startSpeed=puissance;
				x=(y*max_rate)/100;
				particle.emissionRate=x;
			}

	}

	void OnGUI()
	{
		puissance=GUI.VerticalSlider(new Rect(0,Screen.height-110,50,100),puissance,5,0,skin.verticalSlider,skin.verticalSliderThumb);
	}
}
