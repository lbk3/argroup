using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPois{

	private SplitStrings splitString;

	public GetPois(string poi){
		splitString = new SplitStrings (poi);
	}

	public string getId(){
		return splitString.splitString ("ID:");
	}

	public string getName(){
		return splitString.splitString ("Name:");
	}

	public string getTopic(){
		return splitString.splitString ("Topic:");
	}

	public string getInformation(){
		return splitString.splitString ("Information:");
	}

	public string getLatitude(){
		return splitString.splitString ("Latitude:");
	}

	public string getLongitude(){
		return splitString.splitString ("Longitude:");
	}
}
