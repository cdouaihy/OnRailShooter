using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spash : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Invoke("LoadWorld", 2f);
    }

    void LoadWorld()
    {
        SceneManager.LoadScene(1);
    }

    void Awake () {
        DontDestroyOnLoad(gameObject);
	}
}
