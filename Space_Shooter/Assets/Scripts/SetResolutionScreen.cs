using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolutionScreen : MonoBehaviour
{
	void Awake ()
    {
        Screen.SetResolution(640, 400, false);
	}
}
