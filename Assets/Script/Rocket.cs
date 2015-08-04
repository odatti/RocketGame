using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	
	public GameObject MainCamera;
	public GameObject Body;
	public GameObject Core;
	public GameObject Left;
	public GameObject Right;
	public GameObject Top;

	public GameObject Bomb;
	
	private float bombAngle = 0.0f;
	private float bombRenge = 2.0f;
	public float bombPower = 100;
	public int bombNum = 10;
	public int partsNum = 0;

	private int score = 0;

	public int getScore(){
		return score;
	}

	void Start () {
		Body.SetActive(false);
		Bomb.SetActive(false);
		Left.SetActive(false);
		Right.SetActive(false);
		Top.SetActive(false);
		setScore();

//		this.rigidbody2D.velocity.x = 1.0f;
//		this.rigidbody2D.velocity.y = 1.0f;
//		pushRocket(getXYSpeedAtForce(bombPower,60));
//		this.rigidbody2D.AddForce(new Vector2(200.0f,200.0f));
	}
	
	void Update () {
	}
	public void setBombActive(){
		Bomb.gameObject.GetComponent<Bomb>().setBasePos(new Vector2(Core.transform.position.x,Core.transform.position.y));
		Bomb.gameObject.GetComponent<Bomb>().moveCircle(bombRenge,bombAngle);
		Bomb.SetActive(true);

	}


	public void throwBomb(){
		Bomb.gameObject.GetComponent<Bomb>().setBasePos(new Vector2(Core.transform.position.x,Core.transform.position.y));
		Bomb.gameObject.GetComponent<Bomb>().moveCircle(bombRenge,bombAngle);
		bombAngle = (bombAngle < 360)?bombAngle + 3.0f: 0 ;
	}

	public void pushRocket(Vector2 force){
		this.rigidbody2D.AddForce(force);
		bombNum--;
		setScore();
		if(bombNum == 0){
			MainCamera.GetComponent<MainCamera>().gameover();
		}
	}


	public Vector2 getXYSpeedAtForce(float force, float angle){
		Bomb.gameObject.GetComponent<Bomb>().useBomb();
		float theta = angle / 180 * Mathf.PI;
		float x = force * Mathf.Cos(theta);
		float y = force * Mathf.Sin(theta);
		return new Vector2(x,y);
	}

	public float getBombAngle(){
		return bombAngle;
	}

	public void getItem(string tag){
		switch(tag){
		case "ItemBody":
			Body.SetActive(true);
			partsNum++;
			break;
		case "ItemLeft":
			Left.SetActive(true);
			partsNum++;
			break;
		case "ItemRight":
			Right.SetActive(true);
			partsNum++;
			break;
		case "ItemTop":
			Top.SetActive(true);
			partsNum++;
			break;
		case "ItemBomb":
			bombNum++;
			break;
		}
		setScore();
	}
	private void setScore(){
		score = 0;
		score += bombNum * 10;
		score += partsNum * 50;
	}
}
