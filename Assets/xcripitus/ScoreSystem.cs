using UnityEngine;
using UnityEngine.UI;
public class ScoreSystem : MonoBehaviour {
	private static ScoreSystem instance;
	public static ScoreSystem Get(){
		return instance;
	}
	private static int score = 0;
	private static int HighScore = 0;
	public Text scoreText;
	void Awake(){
		if (instance!= null){
			DestroyImmediate(this);
			Debug.LogWarning("Extra scores deleted");
			return;
		}
		instance = this;
	}
	void Start(){
		HighScore = PlayerPrefs.GetInt("highscore");
		ResetScore();
	}
	public static void AddPoint(){
		++score;
		Get().scoreText.text="Score:"+score+"   High score:"+HighScore;
	}
	public int GetScore(){
		return score;
	}
	public static void ResetScore(){
		if (score > HighScore){
			HighScore = score;	
		}
		score=0;
		Get().scoreText.text = "Score:0   High score:"+HighScore;
	}
	public static void SaveScore(){
		PlayerPrefs.SetInt("highscore",HighScore);
	}
}
