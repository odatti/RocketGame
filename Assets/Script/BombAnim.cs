using UnityEngine;
using System.Collections;

public class BombAnim : MonoBehaviour {

	public float deleteTime = 10.0f;


	void Start () {
		deleteTime = Mathf.Abs(deleteTime);
	}
	private float currentTime = 0.0f;
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if(deleteTime < currentTime){
			Destroy(this.gameObject);
		}
	}
}
