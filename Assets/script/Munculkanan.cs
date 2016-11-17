using UnityEngine;
using System.Collections;

public class Munculkanan : MonoBehaviour {
	public gameplay gameplay;
	public GameObject[] GOset;
	public GameObject orang_musuh;
	public GameObject kanan;
	private GameObject orang;
	public TimeCounter timer;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (timer.timesUp && orang!=null)
		{
			Destroy(kanan);
			Destroy (orang);
			Vector3 temp = new Vector3(5.0f,0,0);
			this.gameObject.transform.position += temp;

		}
			
	}

	public void rebuild()
	{
		Vector3 temp = new Vector3(-5.0f,0,0);
		this.gameObject.transform.position += temp;
	}

	public void kloning()
	{
		int[] num = gameplay.angka;
		kanan=(GameObject)Instantiate (GOset[num[2]], new Vector3(1.3f,-2.51f,0f), Quaternion.identity);
//		kanan=(GameObject)Instantiate (GOset[num[2]], transform.position, Quaternion.identity);
		orang=(GameObject)Instantiate (Resources.Load ("orangdesa1"), transform.position, Quaternion.identity);

		//		kanan.name = "orang_kanan";
		Debug.Log (num [0]+" "+num[1]+" "+num[2]+" kanan "+gameplay.angka[2]+gameplay.angka[1]+gameplay.angka[0]);
	}

	void OnMouseDown(){
		StartCoroutine (mulai ());
	}

	IEnumerator mulai()
	{

		int[] num = gameplay.angka;

		scoremanager nilai = GameObject.FindObjectOfType(typeof(scoremanager)) as scoremanager;
		//if cek jawaban load lagu = benar maka +5 else salah
		//  Debug.Log("lagu sekarang: " + answer.tampungjawaban);

		if (num[2]==gameplay.tampungjawaban) {
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
			Debug.Log("timer sekarang "+ timer.startingTime);

			Destroy(kanan);
			Destroy (orang);
			kanan=(GameObject)Instantiate (Resources.Load("orangmusuh"), transform.position, transform.rotation);
			Debug.Log ("kanan1");
			yield return new WaitForSeconds (1);
			gameplay.hapus=true;
		}
		else { nilai.countScore--;
			Debug.Log ("kanan2");
		}
	}
	IEnumerator tunggu(int i)
	{
		yield return new WaitForSeconds (i);
	}

	public void hapus()
	{
		Debug.Log("fungsi hapus kanan");
		Destroy (orang);
		Destroy (kanan);
		Debug.Log("kanan kehapus");
	}

}
