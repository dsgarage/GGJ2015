using UnityEngine;
using System.Collections;

public class NetworkGameSystem : Photon.MonoBehaviour {

	private PhotonView myPhotonView;

	// Use this for initialization
	void Start () {
		GameObject player = PhotonNetwork.Instantiate("ossan", new Vector3(0.0f,1.5f,0.0f), Quaternion.identity, 0);
		player.GetComponent<myThirdPersonController>().isControllable = true;
		player.GetComponent<ThirdPersonCamera>().enabled = true;
		myPhotonView = player.GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI ()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());


	}
}
