using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPois : MonoBehaviour {

	public string[] items;
	private string poiString;

	private GetPois getPois;
	private GetUserPoiPreferences gupp;

	public GameObject prefabToggle;
	public RectTransform ParentPanel;
	public Button showOnMap;
	public Button takeMeThere;

	// Use this for initialization
	IEnumerator Start () {
		WWW itemsData = new WWW ("https://punier-boresights.000webhostapp.com/PoiData.php");
		yield return itemsData;
		string itemsDataString = itemsData.text;

		items = itemsDataString.Split (';');

		for (int i = 0; i < items.Length - 1; i++) {
			getPois = new GetPois (items [i]);

			GameObject toggleCheckbox = (GameObject)Instantiate (prefabToggle);

			toggleCheckbox.transform.SetParent (ParentPanel, false);
			toggleCheckbox.transform.localScale = new Vector3 (1, 1, 1);
			toggleCheckbox.SetActive (true);

			Toggle tempToggle = toggleCheckbox.GetComponent<Toggle> ();

			tempToggle.GetComponentInChildren<Text> ().text = getPois.getName ();

			string tempString = getPois.getId () + "\n"
								+ getPois.getName () + "\n"
								+ getPois.getTopic () + "\n"
								+ getPois.getInformation () + "\n"
								+ getPois.getLatitude () + "\n"
								+ getPois.getLongitude () + "\n";

			string poiId = getPois.getId ();

			gupp = new GetUserPoiPreferences ();

			showOnMap.onClick.AddListener (() => ButtonClicked (tempToggle.isOn, tempString));
			takeMeThere.onClick.AddListener(() => getUserPois (tempToggle.isOn, poiId));
		}
	}

	void ButtonClicked(bool b, string s){
		if (b) {
			print (s);
		}
	}

	void getUserPois(bool isSelected, string id){
		if (isSelected) {
			gupp.addPoi (id);
		}
	}
}
