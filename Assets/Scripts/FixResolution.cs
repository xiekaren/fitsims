﻿using UnityEngine;
using System.Collections;

public class FixResolution : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
