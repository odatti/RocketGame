using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	void Start(){

	}

	void Update(){

	}
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Rocket"){
			collision.gameObject.GetComponent<Rocket>().getItem(this.gameObject.tag);
			Destroy(this.gameObject);
		}
	}

}
