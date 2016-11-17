using UnityEngine;
using System.Collections;

public class Muncultengah : MonoBehaviour {
	public gameplay gameplay;
	public GameObject orang_musuh;
	public GameObject[] GOset;
	public GameObject tengah;
	private GameObject orang;
	public TimeCounter timer;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (timer.timesUp && orang!=null)
		{
			Destroy(tengah);
			Destroy (orang);
			Vector3 temp = new Vector3(10.0f,0,0);
			this.gameObject.transform.position += temp;

		}
			
	}

	public void rebuild(){
		Vector3 temp = new Vector3(-10.0f,0,0);
		this.gameObject.transform.position += temp;
	}

	public void kloning(){
		int[] num = gameplay.angka;
		tengah= (GameObject)Instantiate (GOset[num[1]], new Vector3(0f,-2.51f,0f), transform.rotation);
		orang=(GameObject)Instantiate (Resources.Load ("orangdesa1"), transform.position, Quaternion.identity);
		Debug.Log (num [0]+" "+num[1]+" "+num[2]+" tengah "+gameplay.angka[1]);
	}

	IEnumerator mulai()
	{
		int[] num = gameplay.angka;

		scoremanager nilai = GameObject.FindObjectOfType(typeof(scoremanager)) as scoremanager;
		//if cek jawaban load lagu = benar maka +5 else salah
		//  Debug.Log("lagu sekarang: " + answer.tampungjawaban);

		if (num[1] ==gameplay.tampungjawaban) {
			nilai.countScore += 5;
            if (timer.startingTime + Time.deltaTime * 200 > timer.time_awal)
            {
                timer.startingTime = timer.time_awal;
            }
            else
            {
                timer.startingTime += Time.deltaTime * 200;
            }
            timer.increase += 0.1f;
            Debug.Log("timer sekarang " + timer.startingTime);
			Destroy(tengah);
            Destroy(orang);
			tengah=(GameObject)Instantiate (Resources.Load("orangmusuh"), transform.position, transform.rotation);
			Debug.Log ("tengah1");
			yield return new WaitForSeconds(1);

			gameplay.hapus = true;

		}
		else { nilai.countScore--;
			Debug.Log ("tengah0");
		}

	}
	void OnMouseDown(){
		StartCoroutine(mulai());
	}

	IEnumerator upd()
	{		Debug.Log ("masuk upd tengah");
			yield return new WaitForSeconds (1);
			kloning ();
	}
	IEnumerator tunggu(int i)
	{
		yield return new WaitForSeconds (i);
	}

	public void hapus(){
		Debug.Log("fungsi hapus tengah");
		Destroy (tengah);
		Destroy (orang);
		Debug.Log("tengah kehapus");
	}
}
