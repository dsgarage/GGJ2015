﻿using UnityEngine;
using System.Collections;

public class NetworkGameSystem : Photon.MonoBehaviour {
	
	private PhotonView myPhotonView;
	
	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
		//PhotonNetwork.isMessageQueueRunning = true;
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
		GameObject player = PhotonNetwork.Instantiate("Character01", new Vector3(0.0f,1.5f,0.0f), Quaternion.identity, 0);
		myPhotonView = player.GetComponent<PhotonView>();
		
		if (myPhotonView.isMine) {
			player.gameObject.tag = "Player";
			
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	void OnGUI ()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		
		
	}
}
