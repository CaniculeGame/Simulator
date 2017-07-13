#pragma strict

@script RequireComponent( CharacterController )

var rotateTouchPad : Joystick;						// If unassigned, tilt is used

var cameraPivot : Transform;						// The transform used for camera rotation


var rotationSpeed : Vector2 = Vector2( 1, 1 );	// Camera rotation speed for each axis
var tiltPositiveYAxis = 0.6;
var tiltNegativeYAxis = 0.4;
var tiltXAxisMinimum = 0.1;

private var thisTransform : Transform;
private var character : CharacterController;
private var cameraVelocity : Vector3;
private var velocity : Vector3;						// Used for continuing momentum while in air


	public var  minimumX : float = -360F;
	public var  maximumX : float = 360F;
	
	public var  minimumY : float = -60F;
	public var  maximumY : float = 60F;
	
	var rotationX : float =0;
	var rotationZ : float =0;


function Start()
{
	// Cache component lookup at startup instead of doing this every frame		
	thisTransform = GetComponent( Transform );
	character = GetComponent( CharacterController );	
}

function OnEndGame()
{
	rotateTouchPad.Disable();	
	// Don't allow any more control changes when the game ends
	this.enabled = false;
}

function Update()
{
		var camRotation = Vector2.zero;
		
		if ( rotateTouchPad )
			camRotation = rotateTouchPad.position;
		
			
			rotationX += camRotation.x * rotationSpeed.x;
			rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
			
			rotationZ += camRotation.y * rotationSpeed.y;
			rotationZ = Mathf.Clamp (rotationZ, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationZ, 0, -rotationX);
		
	
		/*camRotation.x *= rotationSpeed.x;
		camRotation.y *= rotationSpeed.y;
		camRotation *= Time.deltaTime;*/
		
		/*camRotation.x = Mathf.Clamp(camRotation.x, minimumX, maximumX);
		camRotation.y = Mathf.Clamp(camRotation.y, minimumY, maximumY);*/
		
		// Rotate the character around world-y using x-axis of joystick
		//thisTransform.Rotate( 0, camRotation.x, 0, Space.World );
		
		// Rotate only the camera with y-axis input
		//cameraPivot.Rotate( -camRotation.y, 0, 0 );
}