using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	private const int Seq_Start = 0;
	private const int Seq_Play = 1;
	private const int Seq_Finish = 2;
	private const int Seq_GameOver = 3;
	private const int Seq_GameClear = 4;
	private const int Seq_Finalize = 5;

	private int Sequence = Seq_Start;

	
	public GameObject Back;
	public GameObject Frame;
	public GameObject BBomb;
	public GameObject BStart;

	public GameObject Rocket;
	public GameObject BlackPane;
	public Material Black;
	// GUI
	public GUIText Score;
	public GUIText Bomb;
	public GUIText Parts;

	public GUIText Message;


	private int finalScore;

	private float finCount = 1.0f;

	void Start () {
//		Back.SetActive(false);
//		Frame.SetActive(false);
		BBomb.SetActive(false);
		Score.gameObject.SetActive(false);
		Bomb.gameObject.SetActive(false);
		Parts.gameObject.SetActive(false);
		Message.gameObject.SetActive(false);
		// 0.0f - 1.0f
		Black.SetColor("_Color",new Color(0.0f, 0.0f, 0.0f, 1.0f));
//		BlackPane.SetActive(false);


	}
	
	void Update () {
		// After this.position sets Rocket Position, translate z axis - 10
//		this.transform.position = Rocket.transform.position;
//		this.transform.Translate(0.0f,0.0f,-10.0f);

		switch(Sequence){
		case Seq_Start:
			this.transform.position = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z -10);
			this.finCount = (finCount > 0.0f) ? finCount - 0.01f : 0.0f ;
			Black.SetColor("_Color",new Color(0.0f, 0.0f, 0.0f, finCount));
			if(finCount == 0.0f){
				Sequence = Seq_Play;
				BlackPane.SetActive(false);
				Black.SetColor("_Color",new Color(0.0f, 0.0f, 0.0f, 1.0f));
				BBomb.SetActive(true);
				BBomb.GetComponent<ButtonBomb>().invertIsGamePlay();
				Score.gameObject.SetActive(true);
				Bomb.gameObject.SetActive(true);
				Parts.gameObject.SetActive(true);
				Rocket.GetComponent<Rocket>().setBombActive();
			}
			break;
		case Seq_Play:
			this.transform.position = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z -10);
			Rocket.GetComponent<Rocket>().throwBomb();
			inform();
			break;
		case Seq_Finish:
			this.transform.position = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z -10);
			this.finCount = (finCount < 1.0f) ? finCount + 0.01f : 1.0f ;
			Black.SetColor("_Color",new Color(0.0f, 0.0f, 0.0f, finCount));
			if(finCount == 1.0f){
				Sequence = nextSequence;
				finCount = 0.0f;
				if(nextSequence == Seq_GameClear){
					Message.guiText.text = "無事、地球へ帰還することができた\n　　　ゲームクリアー！！\n　 　 最終得点：" + finalScore + "点！\n　 　  Titleへ戻ります";
				}else{
					Message.guiText.text = "     地球へ帰還できなかった……　　　　\n　　　ゲームオーバー   \n　    　最終得点：" + finalScore + "点\n　    　Titleへ戻ります";
				}
				Message.gameObject.SetActive(true);
			}
			break;
		case Seq_GameOver:
			inform ();
			finCount+=Time.deltaTime * 10;
			if(finCount >= 50.0f){
				Sequence = Seq_Finalize;
			}
			break;
		case Seq_GameClear:
			inform ();
			finCount+=Time.deltaTime * 10;
			if(finCount >= 50.0f){
				Sequence = Seq_Finalize;
			}
			break;
		case Seq_Finalize:
			Black.SetColor("_Color",new Color(0.0f, 0.0f, 0.0f, 1.0f));
			Application.LoadLevel("Title");
//			Application.Quit();
			break;
		default:
			break;
		}
	}
	private void inform(){
		Score.guiText.text = "Score : " + Rocket.GetComponent<Rocket>().getScore();
		Parts.guiText.text = "= " + Rocket.GetComponent<Rocket>().partsNum;
		Bomb.guiText.text = "= " + Rocket.GetComponent<Rocket>().bombNum;
	}
	private int nextSequence = Seq_GameOver;

	public void gameclear(){
		Sequence = Seq_Finish;
		Rocket.SetActive(false);
		BBomb.SetActive(false);
		nextSequence = Seq_GameClear;
		finalScore = Rocket.GetComponent<Rocket>().getScore() + 2000;
		BlackPane.SetActive(true);
	}
	public void gameover(){
		Sequence = Seq_Finish;
		Rocket.SetActive(false);
		BBomb.SetActive(false);
		nextSequence = Seq_GameOver;
		finalScore = Rocket.GetComponent<Rocket>().getScore();
		BlackPane.SetActive(true);
	}
}
