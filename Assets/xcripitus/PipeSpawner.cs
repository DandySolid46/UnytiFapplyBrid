using UnityEngine;

public class PipeSpawner : MonoBehaviour {
	public GameObject pipes;
	public float spawnTime=2f;
	float lastTime;
	void start () {
		lastTime=Time.time;

	}
	void Update () {
		if(Game.isPlaying&&(Time.time-lastTime>spawnTime)){
			Instantiate(pipes);
			lastTime=Time.time;
		}
	}
}
