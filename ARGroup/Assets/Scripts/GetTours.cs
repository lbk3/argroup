using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTours {

	private SplitStrings splitString;

	public GetTours(string tour){
		splitString = new SplitStrings (tour);
	}

	public string getName(){
		return splitString.splitString ("Name:");
	}

	public string getDescription(){
		return splitString.splitString ("Description:");
	}

	public string getDistance(){
		return splitString.splitString ("Distance:");
	}

	public string getTime(){
		return splitString.splitString ("Estimated Time:");
	}

	public string getStartLat(){
		return splitString.splitString ("Start Lat:");
	}
		

	public string getStartLong(){
		return splitString.splitString ("Start Long:");
	}

	public string getEndLat(){
		return splitString.splitString ("End Lat:");
	}

	public string getEndLong(){
		return splitString.splitString ("Start Long:");
	}
}