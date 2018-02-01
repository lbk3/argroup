using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitStrings {

	private string str;

	public SplitStrings(string s){
		str = s;
	}

	public string splitString(string index){
		string value = str.Substring (str.IndexOf(index)+index.Length);
		if (value.Contains ("|")) {
			value = value.Remove (value.IndexOf ("|"));
		}
		return value;
	}
}
