using UnityEngine;

public class Game:MonoBehaviour{
    private static Game instance;
	public static Game Get(){
		return instance;
    }
    public static bool isPlaying = false;
		public static bool isTyping = false;
    void Awake(){
		if (instance!= null){
			DestroyImmediate(this);
			Debug.LogWarning("Extra Game deleted");
			return;
		}
		instance = this;
	}
}