using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CutScene : MonoBehaviour {

	public int tiempo = 30;
	public VideoPlayer creditos;
	public VideoPlayer inicio;

	public IEnumerator Esperar() {
		

		if (SceneManager.GetActiveScene ().name == "portada") {
			inicio.Play ();
			print (inicio.url);
		} else {
			creditos.Play ();
		}

		yield return new WaitForSeconds(tiempo);
		SceneManager.LoadScene ("perfil1");
	}

	IEnumerator Esperar2() {
		yield return new WaitForSeconds(0);
		SceneManager.LoadScene ("perfil1");
	}

	// Use this for initialization

	void Start () {

		if (SceneManager.GetActiveScene ().name == "portada") {
			inicio = GameObject.Find("Video Inicio").GetComponent<VideoPlayer>();
			inicio.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Inicio.mp4");
			inicio.Prepare ();
		} else {
			creditos = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
			creditos.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Creditos.mp4");
			creditos.Prepare ();
		}

		Debug.Log ("esperar");
		if (Controlador.CantidadDeClicksEntrar >= 0){
				StartCoroutine (Esperar());
			}

		if (Controlador.CantidadDeClicksEntrar > 1){
			StartCoroutine (Esperar2());
		}


	}


	// Update is called once per frame
	void Update () {
		
	}
}
