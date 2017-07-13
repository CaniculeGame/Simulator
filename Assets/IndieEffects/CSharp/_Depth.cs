using UnityEngine;

[RequireComponent(typeof(IndieEffects))]
public class _Depth : MonoBehaviour
{
    public Shader shader;
    public static Texture2D DepthTex;
    public Texture2D tex;
    private GameObject DepthCam;

    private void Start () 
    {
	    DepthTex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        tex = DepthTex;
    }

    private void OnPreCull()
    {
	    if (!DepthCam)
        {
	        DepthCam = new GameObject("DepthCamera");
            Camera cam = DepthCam.AddComponent<Camera>();
            cam.SetReplacementShader(shader, "");
            cam.enabled = false;
            cam.farClipPlane = GetComponent<Camera>().farClipPlane;
            cam.backgroundColor = Color.white;
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.depth = GetComponent<Camera>().depth - 2;
	    }

	    DepthCam.transform.position = transform.position;
	    DepthCam.transform.rotation = transform.rotation;
        DepthCam.GetComponent<Camera>().Render();
        DepthTex.Resize(Mathf.RoundToInt(GetComponent<Camera>().pixelWidth), Mathf.RoundToInt(GetComponent<Camera>().pixelHeight), TextureFormat.RGB24, false);
	    DepthTex.ReadPixels(new Rect(0,0,Screen.width, Screen.height), 0, 0);
	    DepthTex.Apply();	
    }
}