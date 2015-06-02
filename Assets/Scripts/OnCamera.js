#pragma strict

function Start () {

}

function Update () {

}
// Draw a yellow sphere in the scene view at the position
// on the near plane of the selected camera that is
// 100 pixels from lower-left.
function OnDrawGizmosSelected() {
	var camera = GetComponent.<Camera>();
	var p = camera.ScreenToWorldPoint(new Vector3(100, 100, camera.nearClipPlane));
	Gizmos.color = Color.yellow;
	Gizmos.DrawSphere(p, 0.1F);
}