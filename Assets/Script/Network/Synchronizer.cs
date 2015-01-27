using UnityEngine;
using System.Collections;


//Animationの設定を行うスクリプト
public class Synchronizer : Photon.MonoBehaviour {
	//protected Animator anim;

	private Vector3 correctPlayerPos = Vector3.zero; // We lerp towards this
	private Quaternion correctPlayerRot = Quaternion.identity; // We lerp towards this
	private Vector3 correctVelocity = Vector3.zero;

	void Update()
	{
		if (!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		// データを送る
		if (stream.isWriting)
		{
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(rigidbody.velocity);
		

			/*
			// アニメーションの連携
			anim = GetComponent< Animator >();
			stream.SendNext(anim.GetFloat("Speed"));
			stream.SendNext(anim.GetFloat("Direction"));
			stream.SendNext(anim.GetBool("Jump"));
			stream.SendNext(anim.GetBool("Rest"));
			stream.SendNext(anim.GetFloat("JumpHeight"));
			stream.SendNext(anim.GetFloat("GravityControl"));
			*/
		} else {
			//データの受信
			/*
			transform.position = (Vector3)stream.ReceiveNext();
			transform.rotation = (Quaternion)stream.ReceiveNext();
			rigidbody.velocity = (Vector3)stream.ReceiveNext();
			*/
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			rigidbody.velocity = (Vector3)stream.ReceiveNext();
			/*
			anim = GetComponent< Animator >();
			anim.SetFloat("Speed",(float)stream.ReceiveNext());
			anim.SetFloat("Direction",(float)stream.ReceiveNext());
			anim.SetBool("Jump",(bool)stream.ReceiveNext());
			anim.SetBool("Rest",(bool)stream.ReceiveNext());
			anim.SetFloat("JumpHeight",(float)stream.ReceiveNext());
			anim.SetFloat("GravityControl",(float)stream.ReceiveNext());
			}*/
		}
	}
}