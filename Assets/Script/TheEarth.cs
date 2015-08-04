using UnityEngine;
using System.Collections;

public class TheEarth : MonoBehaviour {

	
	public GameObject MainCamera;
	private Vector3 defaultPos;
	void Start () {
		defaultPos = transform.position;
	}
	void Update () {
		transform.position = defaultPos;
	}
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Rocket"){
			MainCamera.GetComponent<MainCamera>().gameclear();
		}
	}
}
