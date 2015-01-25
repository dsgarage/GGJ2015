using UnityEngine;
using System.Collections;

public class NetworkGameSystem : Photon.MonoBehaviour {

	private PhotonView myPhotonView;

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
		PhotonNetwork.isMessageQueueRunning = true;
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
		Debug.Log(PhotonNetwork.connected.ToString());
	}
	
	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}
	
	
	void OnJoinedRoom()
	{
		if (PhotonNetwork.isMasterClient) {
			Debug.Log ("Master");		
		} else {
			Debug.Log ("Client");		
		}

		GameObject player = PhotonNetwork.Instantiate("PhotonFPS", new Vector3(0.0f,1.5f,0.0f), Quaternion.identity, 0);
		//player.GetComponent<myThirdPersonController>().isControllable = true;
		//player.GetComponent<ThirdPersonCamera>().enabled = true;
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
