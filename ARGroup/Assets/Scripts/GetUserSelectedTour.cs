using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUserSelectedTour : MonoBehaviour {

	static string[] tourPois;
	string[] emptyArray;
	static int tourId = 0;
	static private string startLat, startLong, endLat, endLong;
	string tourPoisLink = "https://punier-boresights.000webhostapp.com/GetTourPois.php";
	private GetPois getPois;

	public GetUserSelectedTour(){

	}

	// Use this for initialization
	IEnumerator Start () {
		print ("Loading Tour Poi's");

		WWWForm form = new WWWForm ();

		form.AddField ("tourIdPost", tourId);

		WWW www = new WWW (tourPoisLink, form);

		yield return www;

		string theTour = www.text;
		tourPois = theTour.Split (';');

		print ("Start lat & long: " + startLat + ", " + startLong);

		for (int i = 0; i< tourPois.Length - 1; i++) {
			string poi = tourPois [i];
			getPois = new GetPois (poi);
			print ("Poi Name: " + getPois.getName() );
			print ("Poi Info: " + getPois.getInformation ());
			print ("Poi Coordinates: " + getPois.getLatitude() + ", " + getPois.getLongitude());
		}

		print ("End lat & long: " + endLat + ", " + endLong);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy(){
		tourPois = emptyArray;
		tourId = 0;
		startLat = "";
		startLong = "";
		endLat = "";
		endLong = "";
	}

	public void setTourId(int id){
		tourId = id;
	}

	public void setStartLat(string sl){
		startLat = sl;
	}

	public void setStartLong(string sl){
		startLong = sl;
	}

	public void setEndLat(string el){
		endLat = el;
	}

	public void setEndLong(string el){
		endLong = el;
	}
}
