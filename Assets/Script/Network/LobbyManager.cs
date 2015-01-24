using UnityEngine;
using System.Collections;

public class LobbyManager : Photon.MonoBehaviour {

	private bool isConnected = false;

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
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
		isConnected = true;
		//GUILayout.Label (PhotonNetwork.room.playerCount.ToString ());
	}


	void OnGUI(){
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		if (isConnected) {
			GUILayout.Label ( "Connected : " + PhotonNetwork.room.playerCount.ToString ());		
		}
		if (PhotonNetwork.isMasterClient) {
			if (GUILayout.Button ("StartGame")) {
								PhotonNetwork.LoadLevel ("00_Level01");
						}
				}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
