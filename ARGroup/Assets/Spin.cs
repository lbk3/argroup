using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public float spinSpeed = 10f;
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
		
	}
}
