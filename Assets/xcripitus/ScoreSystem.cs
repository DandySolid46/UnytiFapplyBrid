using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
	public static int GetScore(){
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
		var highscores = new List<int>(10);
		var names= new List<string>(10);
		for (int i = 0;i<10;++i){
			highscores[i]=PlayerPrefs.GetInt("highscore"+i,0);
			names[i]=PlayerPrefs.GetString("name"+i,"AAA");
		}
		for(int i = 0; i<10;++i){
		PlayerPrefs.SetInt("highscore"+i,highscores[i]);
		PlayerPrefs.SetString("name"+i,names[i]);
		}
	}
}
