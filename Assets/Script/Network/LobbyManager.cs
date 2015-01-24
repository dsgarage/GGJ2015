using UnityEngine;
using System.Collections;

public class LobbyManager : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedLobby()
	{
		Debug.Log("JoinRandom");
		PhotonNetwork.JoinRandomRoom();
		Debug.Log(PhotonNetwork.connected.ToString());
	}
	
	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}


	void OnJoinedRoom()
	{

		//GUILayout.Label (PhotonNetwork.room.playerCount.ToString ());
	}


	void OnGUI(){
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		if(GUILayout.Button ("JoinGame")){
			Application.LoadLevel ("TestScene");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
