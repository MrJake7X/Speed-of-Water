using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIntro : MonoBehaviour {

    public Image panel;
    public GameObject title;
    public float titlePosX;
    private float alpha = 0.4f;

    private float timeCounter = 0;
    private float fadeCounter = 0;

	// Use this for initialization
	void Start ()
    {
        titlePosX = title.transform.position.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        titlePosX = title.transform.position.x;
        if (titlePosX >= 12.7f)
       {
            timeCounter += Time.deltaTime;
            if (timeCounter >= 2f)
            {
                panel.color += new Color(0, 0, 0, alpha) * Time.deltaTime;
                if (panel.color.a >= 1)
                {
                    fadeCounter += Time.deltaTime;
                    if (fadeCounter >= 0.5f)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
            }
        }
	}
}
