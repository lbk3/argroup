using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPois : MonoBehaviour {

	public string[] items;
	public Text poiText;
	private string poiString;

	// Use this for initialization
	IEnumerator Start () {
		WWW itemsData = new WWW ("https://punier-boresights.000webhostapp.com/PoiData.php");
		yield return itemsData;
		string itemsDataString = itemsData.text;

		items = itemsDataString.Split (';');
		for (int i = 0; i < items.Length-1; i++) {
			print (getDataValue (items [i], "Name:"));
			poiString = poiString + getDataValue (items [i], "Name:") + "\n";
		}

		poiText.text = poiString;

	}

	string getDataValue(string data, string index){
		string value = data.Substring (data.IndexOf(index)+index.Length);
		if (value.Contains ("|")) {
			value = value.Remove (value.IndexOf ("|"));
		}
		return value;
	}
}
