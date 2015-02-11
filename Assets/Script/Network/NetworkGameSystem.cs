using UnityEngine;
using System.Collections;

public class NetworkGameSystem : Photon.MonoBehaviour {
	
	private PhotonView myPhotonView;
	private Vector3 SpawnPos;

	public	GUIStyle	style;
	
	// Use this for initialization
	void Start () {
		//PhotonNetwork.ConnectUsingSettings("0.2");
		PhotonNetwork.isMessageQueueRunning = true;
		SpawnPos = new Vector3(Random.Range(-19.0f, 15.0f),4.5f,Random.Range(-30.0f, 16.0f));
		GameObject player = PhotonNetwork.Instantiate("Character01",SpawnPos, Quaternion.identity, 0);
		myPhotonView = player.GetComponent<PhotonView>();
		
		if (myPhotonView.isMine) {
			player.gameObject.tag = "Player";
			
		}

	}
	
	void OnJoinedLobby()
	{
		//PhotonNetwork.JoinRandomRoom();
		Debug.Log(PhotonNetwork.connected.ToString());
	}
	
	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}
	
	
	void OnJoinedRoom()
	{
		GameObject player = PhotonNetwork.Instantiate("Character01", new Vector3(0.0f,4.5f,0.0f), Quaternion.identity, 0);
		myPhotonView = player.GetComponent<PhotonView>();
		/*
		if (myPhotonView.isMine) {
			player.gameObject.tag = "Player";
			
		}
		*/
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void OnGUI ()
	{
		style.fontSize = (int)(Screen.width * 0.03);
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString(),style);
	}
}
