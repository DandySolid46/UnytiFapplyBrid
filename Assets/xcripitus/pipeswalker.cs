using UnityEngine;

public class pipeswalker : MonoBehaviour {
	public float speed = 1f;
	
	void Start () {
		var startPos = Camera.main.ViewportToWorldPoint(new Vector2(1.25f,0.5f));
		var pos = transform.position;
		pos.x = startPos.x;
		transform.position=pos;
		transform.Translate(0f,Random.Range(-2,2),0f);
	}
	
	void FixedUpdate () {
		transform.Translate(-speed,0f,0f);

		var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(-0.25f , 0f));
		if (transform.position.x<leftBorder.x)
			Destroy(this.gameObject);
	}
}
