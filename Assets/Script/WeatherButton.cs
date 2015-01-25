using UnityEngine;
using System.Collections;

public class WeatherButton : MonoBehaviour {

	private GameObject m_button;
	private FSPlayer m_fsplayer;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		m_button = GameObject.Find("Wezer");
		m_fsplayer = (FSPlayer) m_button.GetComponent< FSPlayer >();
		m_fsplayer.SkyBoxButton();
	}
}
