using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSound : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        FindObjectOfType<AudioManager>().Play("GameplayMusic");
    }
}
