using UnityEngine;
using System.Collections;

public class MunculKiri : MonoBehaviour {
	public gameplay gameplay;
	public GameObject[] GOset;
	public GameObject orang_musuh;
	public GameObject kiri;
//	private bool replayy=false;
	private GameObject orang;
	public TimeCounter timer;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		if (timer.timesUp==true && orang!=null)
		{
			Destroy(kiri);
			Destroy (orang);
			Vector3 temp = new Vector3(-5.0f,0,0);
			this.gameObject.transform.position += temp;
		}
	}

	public void rebuild()
	{ 
		Vector3 temp = new Vector3(5.0f,0,0);
		this.gameObject.transform.position += temp;
	}

	public void kloning()
	{
		int[] num = gameplay.angka;
		kiri= (GameObject) Instantiate (GOset[num[0]], new Vector3(-1.3f,-2.51f,0f), transform.rotation);
		orang= (GameObject)Instantiate (Resources.Load ("orangdesa1"), transform.position, Quaternion.identity);
		Debug.Log (num [0]+" "+num[1]+" "+num[2]+" kiri "+gameplay.angka[0]+gameplay.angka[1]+gameplay.angka[2]);
	}

	IEnumerator mulai()
	{
		int[] num = gameplay.angka;

		scoremanager nilai = GameObject.FindObjectOfType(typeof(scoremanager)) as scoremanager;
		//if cek jawaban load lagu = benar maka +5 else salah
		//  Debug.Log("lagu sekarang: " + answer.tampungjawaban);

		if (num[0] ==gameplay.tampungjawaban) {
			nilai.countScore += 5; 
            if(timer.startingTime+Time.deltaTime*200 > timer.time_awal)
            {
                timer.startingTime = timer.time_awal;
            }
            else
            { 
			timer.startingTime += Time.deltaTime*200;
            }

            timer.increase += 0.1f;
            Debug.Log("timer sekarang " + timer.startingTime);

            Destroy(kiri);
			Destroy(orang);
			kiri=(GameObject)Instantiate (Resources.Load("orangmusuh"), transform.position, transform.rotation);
			Debug.Log ("kiri1");
			yield return new WaitForSeconds(1);
			Destroy (kiri);
			gameplay.hapus=true;

		}
		else { nilai.countScore--;
			Debug.Log ("kiri0");
		}
	}

	void OnMouseDown(){
		
		StartCoroutine(mulai());
}
	public void hapus()
	{
		Debug.Log("fungsi hapus kiri");

		Destroy (orang);
		Destroy (kiri);
		Debug.Log("kiri deleted");

	}
}
