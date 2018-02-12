using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUserPoiPreferences : MonoBehaviour{

	static ArrayList userPreferedPois = new ArrayList();

	public GetUserPoiPreferences(){
		
	}

	// Use this for initialization
	void Start () {
		foreach (string s in userPreferedPois) {
			print (s);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void OnDestroy(){
		userPreferedPois = new ArrayList();
	}

	public ArrayList getPois(){
		return userPreferedPois;
	}

	public void addPoi(string s){
		userPreferedPois.Add (s);
	}
}
