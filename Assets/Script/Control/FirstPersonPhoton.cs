using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]


public class FirstPersonPhoton : MonoBehaviour {

	//Character Config
	public float moveSpeed;
	public float rotateSpeed;
	public float backSpeed;
	public float jumpHeight;

	public bool isControllable;

	private GameObject cameraObject;

	private Animator anim;
	private AnimatorStateInfo currentBaseState;

	/*
	static int idleState = Animator.StringToHash("Base Layer.Idle");
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");
	static int jumpState = Animator.StringToHash("Base Layer.Jump");
	static int restState = Animator.StringToHash("Base Layer.Rest");
	 */

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
