using UnityEngine;
using System.Collections;

public class Char_Select : MonoBehaviour {

	public GameObject	NetworkManager;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseOver ()
	{
		this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,4.0f);

	}

	void OnMouseExit() {
		this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,5.0f);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
