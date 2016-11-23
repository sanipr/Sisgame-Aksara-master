using UnityEngine;
using System.Collections;


public class exit : MonoBehaviour {

  //  private string idgame = "1208577";

    // Use this for initialization
    void Start () {
		Debug.Log ("exit jalan");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
        
       Application.Quit();
		Debug.Log ("close");
	}

	public void visible(){
		Vector3 temp = new Vector3(-9.0f,0,0);
		this.gameObject.transform.position += temp;	
	}
	public void invisible(){
		Vector3 temp = new Vector3(9.0f,0,0);
		this.gameObject.transform.position += temp;	
	}
   
}
