#pragma strict


private var gui : GUITexture;								// Joystick graphic
private var defaultRect : Rect;								// Default position / extents of the joystick graphic
var Texture : Texture2D;

var Scale	=	0;

var prefix : float = 1.00;

private var Size : float = 0.00 ;
private var Res : float = 0.00;

function Start () {

	Res = Screen.width;
	Size = (Res /2048);
	
gui = GetComponent( GUITexture );

	// Store the default rect for the gui, so we can snap back to it
	defaultRect =  gui.pixelInset;	
    
    defaultRect.x = transform.position.x * Screen.width;// + gui.pixelInset.x; // -  Screen.width * 0.5;
    defaultRect.y = transform.position.y * Screen.height;// - Screen.height * 0.5;
    
    if(Scale == 1){
    defaultRect.width = ((Texture.width * Size)/prefix);
    defaultRect.height = ((Texture.height * Size)/prefix);
    }
    
    transform.position.x = 0.0;
    transform.position.y = 0.0;
    
    gui.pixelInset = defaultRect;
    Debug.Log("GUI : " +defaultRect);
    

}

function Update () {

}