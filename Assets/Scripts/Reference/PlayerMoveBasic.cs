using UnityEngine;
using System.Collections;

public class PlayerMoveBasic : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private Animator anim;

	void Start () {
		anim = this.transform.GetComponent<Animator> ();
	}

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump")){
				moveDirection.y = jumpSpeed;
				StartCoroutine ( TriggerAnimatorBool("Jump"));
				//StartCoroutine ( Jump());
			}else{
					
			}
					
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	private IEnumerator TriggerAnimatorBool (string name){
		anim.SetBool(name, true);
		yield return null;
		anim.SetBool(name, false);
	}

	private IEnumerator Jump (){
		float timer = 0;
		while(timer < 0.5f){
			timer += Time.deltaTime;
			//controller.Move((Vector3.up * jumpSpeed) * Time.deltaTime);
			yield return null;
		}
	}
}
