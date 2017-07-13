#pragma strict

@script RequireComponent(IndieEffects)
import IndieEffects;

var shader : Shader;
static var DepthTex : Texture2D;
var tex : Texture2D;
private var DepthCam : GameObject;
function Start () {
	DepthTex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
}

function Update () {
	tex = DepthTex;
}

function OnPreCull () {
	if (!DepthCam){
	DepthCam = new GameObject("DepthCamera");
	DepthCam.AddComponent.<Camera>();
	DepthCam.GetComponent.<Camera>().SetReplacementShader(shader,"");
	DepthCam.GetComponent.<Camera>().enabled = false;
	DepthCam.GetComponent.<Camera>().farClipPlane = GetComponent.<Camera>().farClipPlane;
	DepthCam.GetComponent.<Camera>().backgroundColor = Color.white;
	DepthCam.GetComponent.<Camera>().clearFlags = CameraClearFlags.SolidColor;
	DepthCam.GetComponent.<Camera>().depth = GetComponent.<Camera>().depth-2;
	}
	DepthCam.transform.position = transform.position;
	DepthCam.transform.rotation = transform.rotation;
	DepthCam.GetComponent.<Camera>().Render();
	DepthTex.Resize(GetComponent.<Camera>().pixelWidth,GetComponent.<Camera>().pixelHeight,TextureFormat.RGB24,false);
	DepthTex.ReadPixels(Rect(0,0,Screen.width, Screen.height), 0, 0);
	DepthTex.Apply();
}