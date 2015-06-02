#pragma strict

var rend: Renderer;


function Start() {
	rend = GetComponent.<Renderer>();
}


function Update () {
	rend.material.color.a = 0.25;
}