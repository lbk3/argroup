using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTours {

	private string theTour;
	private string name, description, distance, est_time, start_lat, start_long, end_lat, end_long;

	public GetTours(string tour){
		theTour = tour;
		setName ();
		setDescription ();
		setDistance ();
		setTime ();
		setStartLat ();
		setStartLong ();
		setEndLat ();
		setEndLong ();
	}

	public string getName(){
		return name;
	}

	private void setName(){
		name = splitString ("Name:");
	}

	public string getDescription(){
		return description;
	}

	private void setDescription(){
		description = splitString ("Description:");
	}

	public string getDistance(){
		return distance;
	}

	private void setDistance(){
		distance = splitString ("Distance:");
	}

	public string getTime(){
		return est_time;
	}

	private void setTime(){
		est_time = splitString ("Estimated Time:");
	}

	public string getStartLat(){
		return start_lat;
	}

	private void setStartLat(){
		start_lat = splitString ("Start Lat:");
	}

	public string getStartLong(){
		return start_long;
	}

	private void setStartLong(){
		start_long = splitString ("Start Long:");
	}

	public string getEndLat(){
		return end_lat;
	}

	private void setEndLat(){
		end_lat = splitString ("End Lat:");
	}

	public string getEndLong(){
		return start_long;
	}

	private void setEndLong(){
		start_long = splitString ("Start Long:");
	}

	string splitString(string index){
		string value = theTour.Substring (theTour.IndexOf(index)+index.Length);
		if (value.Contains ("|")) {
			value = value.Remove (value.IndexOf ("|"));
		}
		return value;
	}

}