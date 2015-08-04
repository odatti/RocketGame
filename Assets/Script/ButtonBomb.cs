using UnityEngine;
using System.Collections;

public class ButtonBomb : MonoBehaviour {
	
	public GameObject Rocket;
	private bool isGamePlay = false;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
		if(isGamePlay){
			blastBomb();
		}
	}
	public void invertIsGamePlay(){
		isGamePlay = !isGamePlay;
	}
	void OnMouseUp(){
	}

	void OnMouseExit(){

	}
	
	void OnMouseOver(){
		
	}
	void OnMouseDrag(){
	}

	private void blastBomb(){
		float angle = Rocket.gameObject.GetComponent<Rocket>().getBombAngle();
		float power = Rocket.gameObject.GetComponent<Rocket>().bombPower;
		angle = (angle+180<360)?angle+180:angle-180;
		Rocket.gameObject.GetComponent<Rocket>().pushRocket(
			Rocket.gameObject.GetComponent<Rocket>().getXYSpeedAtForce(power,angle)
		);
	}
}

