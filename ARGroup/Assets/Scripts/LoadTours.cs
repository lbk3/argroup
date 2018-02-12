using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTours : MonoBehaviour {

	public string[] tours;
	public Text tourName;
	public Text tourDescription;
	public Text tourDistance;
	public Text tourTime;
	public string tourPois;
	private string startLat, startLong, endLat, endLong;
	private string toursString;

	public GameObject prefabButton;
	public RectTransform ParentPanel;
	public Button startTour;

	string tourNamesLink = "https://punier-boresights.000webhostapp.com/TourData.php";
	string tourInformationLink = "https://punier-boresights.000webhostapp.com/TourInformation.php";

	private SplitStrings splitString;
	private GetUserSelectedTour gust;

	// Use this for initialization
	IEnumerator Start () {
		//Reads in ID and Name of each tour
		WWW toursData = new WWW (tourNamesLink);
		yield return toursData;

		//Convert data to String and split with each ';'
		string toursDataString = toursData.text;
		tours = toursDataString.Split (';');

		//Creates button for each tour
		for (int i = 0; i < tours.Length-1; i++) {

			print(i);

			GameObject goButton = (GameObject)Instantiate (prefabButton);

			goButton.transform.SetParent (ParentPanel, false);
			goButton.transform.localScale = new Vector3 (1, 1, 1);
			goButton.SetActive (true);

			Button tempButton = goButton.GetComponent<Button> ();

			splitString = new SplitStrings (tours[i]);

			tempButton.GetComponentInChildren<Text>().text = splitString.splitString ("Name:");

			int tempInt = i + 1;

			tempButton.onClick.AddListener (() => ButtonClicked (tempInt));
		}
			
	}

	void ButtonClicked(int buttonNo){
		Debug.Log ("Button clicked = " + buttonNo);
		startTour.onClick.AddListener (() => startTheTour(buttonNo, startLat, startLong, endLat, endLong));
		StartCoroutine(getTourInformation(buttonNo));
	}

	IEnumerator getTourInformation(int tourId){
		WWWForm form = new WWWForm ();

		form.AddField ("tourIdPost", tourId);

		WWW www = new WWW (tourInformationLink, form);

		yield return www;

		GetTours getTours = new GetTours (www.text);

		tourName.text = getTours.getName();
		tourDescription.text = getTours.getDescription ();
		tourDistance.text = "Distance: " + getTours.getDistance ();
		tourTime.text = "Est. Time: " + getTours.getTime ();
		startLat = getTours.getStartLat ();
		startLong = getTours.getStartLong ();
		endLat = getTours.getEndLat ();
		endLong = getTours.getEndLong ();
	}

	void startTheTour(int theTourId, string tourStartLat, string tourStartLong, string tourEndLat, string tourEndLong){
		print ("Starting tour" + theTourId);
		gust = new GetUserSelectedTour ();
		gust.setTourId (theTourId);
		gust.setStartLat (tourStartLat);
		gust.setStartLong (tourStartLong);
		gust.setEndLat (tourEndLat);
		gust.setEndLong (tourEndLong);
	}
}
