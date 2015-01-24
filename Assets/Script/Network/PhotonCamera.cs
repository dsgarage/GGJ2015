using UnityEngine;
using System.Collections;

public class PhotonCamera : Photon.MonoBehaviour {
	public GameObject CameraObject;
	
	void Start () {
		if (!photonView.isMine) {
			CameraObject = GameObject.FindGameObjectWithTag("MainCamera");
			CameraObject.transform.parent = this.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
