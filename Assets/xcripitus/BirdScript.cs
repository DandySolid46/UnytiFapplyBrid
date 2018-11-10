using UnityEngine;
using static UnityEngine.Mathf;
public class BirdScript : MonoBehaviour {
	Vector3 startPos;
	public float speed = 200f;
	Rigidbody2D rb2d;
	public float rotationVelocity;
	float rotation;
	public float rotationFallTime;
	

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Start() {
		startPos = transform.position;
	}

	void FixedUpdate() {
		if ((rotation > -45)&Game.isPlaying){
			rotation -= Pow(1.3f, rotationVelocity) * Time.deltaTime;
			rotationVelocity += 1 ;
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			Game.isPlaying = rb2d.simulated = true;
			rb2d.velocity = Vector2.up * speed ;
			rotationVelocity = 0;
			rotation = 45f;
		} else if (!Game.isPlaying) {
			rb2d.simulated = false;
			rb2d.velocity = Vector2.zero;
			var pos = transform.position;
			pos.y = Mathf.Sin(Time.time * 4f) * 0.15f;
			transform.position = pos;
			rotation = 0;
		}
		var rot = transform.rotation;
		rot.eulerAngles = new Vector3(0f, 0f, rotation);
		transform.rotation = rot;
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.transform.tag == "Pipe") {
			Game.isPlaying = rb2d.simulated = false;

			rb2d.velocity = Vector2.zero;
			transform.position = startPos;

			var pipes = FindObjectsOfType<pipeswalker>();

			for(int i = 0; i < pipes.Length; ++i)
				Destroy(pipes[i].gameObject);

			ScoreSystem.ResetScore();
		}
	}
	void OnTriggerEnter2D(Collider2D c) {
		if (c.transform.tag == "Score")
			ScoreSystem.AddPoint();
	}
}
