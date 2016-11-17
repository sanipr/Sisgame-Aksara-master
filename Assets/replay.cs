using UnityEngine;
using System.Collections;

public class replay : MonoBehaviour {
	public gameplay gameplay;
	public bool visible=false;
	public exit exit;
	// Use this for initialization
	void Start () {
		Debug.Log ("replay jalan");
	}
	
	// Update is called once per frame
	void Update () {
		if (gameplay.buttonreplay) {
				Vector3 temp = new Vector3(9.0f,0,0);
				this.gameObject.transform.position += temp;	
				visible = true;
				exit.visible ();
			gameplay.buttonreplay = false;
			Debug.Log ("replay update jalan");
		}
	}
	void OnMouseDown(){
		gameplay.replay = true;
		hiddenposition ();
		exit.invisible ();
		visible = false;
	}
	public void hiddenposition()
	{
		Vector3 temp = new Vector3(-9.0f,0,0);
		this.gameObject.transform.position += temp;
	}
}
