using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]


public class gameplay : MonoBehaviour {

	public MunculKiri mkiri;
	public Munculkanan mkanan;
	public Muncultengah mtengah;
    public question[] pertanyaan;
    private static List<question> belumdijawab;
	public GameObject coba;
    private question currentpertanyaan;
    public int tampungjawaban;
	public int[] angka;
	public bool hapus = false;
	public bool flagg=false;
	public bool play=false;
	public bool timeon=false;
	public bool goo = false;
	public bool replay=false;
	public bool buttonreplay=false;
    public TimeCounter timer;
    public Image timebar;
    public Image background;
	public scoremanager score;
	public GameObject exit;
    // Use this for initialization
	void Start () {

        

		Screen.orientation	= ScreenOrientation.Portrait;
		exit = (GameObject)Instantiate (Resources.Load ("exit1"), new Vector3(1.61f,-3.62f,-1f), transform.rotation);
	}

	void Update(){
		
		if (play) {
			go ();

            RectTransform rt = timebar.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(0, 29);

            RectTransform rt2 = background.GetComponent(typeof(RectTransform)) as RectTransform;
            rt2.sizeDelta = new Vector2(0, 29);

            //timer.tinggi = 29;
            play = false;
		}

		if (replay) {
			
			Destroy(timer.image_gameOver);
			score.reset ();

			timer.timesUp = false;
			timer.time_awal = timer.startingTime = 10;
			timer.stop = false;
			timeon = true;

			mkiri.rebuild ();
			mtengah.rebuild ();
			mkanan.rebuild ();
			go ();

			RectTransform rt = timebar.GetComponent(typeof(RectTransform)) as RectTransform;
			rt.sizeDelta = new Vector2(0, 29);

			RectTransform rt2 = background.GetComponent(typeof(RectTransform)) as RectTransform;
			rt2.sizeDelta = new Vector2(0, 29);
			replay = false;
		}
		if (hapus) {
			Debug.Log ("hapus" + hapus);
			currentpertanyaan.suara.Stop();
			mkiri.hapus ();
			mtengah.hapus ();
			mkanan.hapus ();
			go ();
			hapus = false;
		}
	}

	public void go()
	{   

			if (belumdijawab == null || belumdijawab.Count == 0) {
				belumdijawab = pertanyaan.ToList<question> ();
			}

			getRandomPertanyaan ();

			currentpertanyaan.suara.Play ();
			tampungjawaban = currentpertanyaan.jawaban;
			Debug.Log ("lagu sekarang: " + tampungjawaban);

//			cari posisi jawaban benar
			int posbenar = Random.Range (0, 5);
		if (posbenar > 2) {
			switch (posbenar) {
			case 3:
				posbenar = 0;
				break;
			case 4:
				posbenar = 1;
				break;
			case 5:
				posbenar = 2;
				break;
			}


		}
			for (int i = 0; i <= 2; i++) {
				int angkalain;
				if (i == posbenar)
					angka [i] = tampungjawaban;
				else {
					angkalain = Random.Range (0, 19);
				while (angkalain == tampungjawaban) {
						angkalain = Random.Range (0, 19);
					}
					angka [i] = angkalain;
				}
			}
//		goo = true;
		mkiri.kloning();
		mtengah.kloning ();
		mkanan.kloning ();
	}

    void getRandomPertanyaan()
    {
        int indexRandom = Random.Range(0, belumdijawab.Count);
        currentpertanyaan = belumdijawab[indexRandom];
        belumdijawab.RemoveAt(indexRandom);
    }

   


    IEnumerator tunggu(int i)
	{
		yield return new WaitForSeconds (i);
	}


	
	
}
