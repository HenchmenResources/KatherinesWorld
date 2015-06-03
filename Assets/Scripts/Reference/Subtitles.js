#pragma strict
import UnityEngine.UI;

var images:Texture2D[];
var voices:AudioClip[];
var subtitles:String[];
var enableSpeech:boolean=false;
var comboPointer:int=0; 
var maxDialogue:int;
public var nextMap : String;
//var images:Texture2D[];
//var voices:AudioClip[];
//var subtitles:String[];
//var maxDialogue:int;

function Start() {
	//other.gameObject.GetComponent("DialogueScript").images=images;
	//other.gameObject.GetComponent("DialogueScript").voices=voices;
	//other.gameObject.GetComponent("DialogueScript").subtitles=subtitles;
	//other.gameObject.GetComponent("DialogueScript").maxDialogue=maxDialogue;
	enableSpeech=true;
	StartDialogue();
	//Destroy(gameObject); 
}

function Update() {
	
}

function OnGUI () {
	if(enableSpeech){
		GUI.Box(Rect(140,Screen.height-130,Screen.width-300,120),"");
		GUI.DrawTexture(Rect(150,Screen.height-120,60,60),images[comboPointer], ScaleMode.StretchToFill, true, 10.0f);
		GUI.Label(Rect(220,Screen.height-120,Screen.width-230,110),subtitles[comboPointer]);

	}
}

function StartDialogue(){
Debug.Log("Blonk!");
	GetComponent.<AudioSource>().PlayOneShot(voices[comboPointer]);
	yield WaitForSeconds(voices[comboPointer].length+0.4);
	if(comboPointer==maxDialogue-1){
		enableSpeech=false; 
		images=null;
		voices=null;
		subtitles=null;
		comboPointer=0; 
		maxDialogue=0;
		if (nextMap == "quit") {
		Application.Quit();
		}else{
		Application.LoadLevel(nextMap);
		}
	} else {
		comboPointer++;
		RestartDialogue();
	}
}

function RestartDialogue(){ StartDialogue(); }