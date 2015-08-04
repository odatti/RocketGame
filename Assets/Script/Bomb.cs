using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	private Vector2 basePos = new Vector2(0.0f,0.0f);

	public GameObject blastEffect;

	private Quaternion defaultRotate;


	void Start () {
		transform.Translate(new Vector3(0,0,0));
		defaultRotate = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = defaultRotate;

	}

	public void moveCircle(float r, float angle){
		float theta = angle / 180 * Mathf.PI;
		float x = basePos.x + r * Mathf.Cos(theta);
		float y = basePos.y + r * Mathf.Sin(theta);
		this.transform.position = new Vector3(x,y,-4.0f);
	}

	public void setBasePos(Vector2 first){
		basePos = first;
	}

	public void useBomb(){
		GameObject blast = GameObject.Instantiate(blastEffect) as GameObject;
		blast.transform.position = transform.position;
	}

}
