using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGPS : MonoBehaviour {

	public static GetGPS Instance { set; get; }

	public float latitude;
	public float longitude;

	private void Start()
	{
		Instance = this;
		DontDestroyOnLoad (gameObject);
		StartCoroutine (StartLocationService());
	}

	private void Update(){
		Instance = this;
		StartCoroutine (UpdateLocation ());
	}

	private IEnumerator StartLocationService ()
	{
		//Make sure user enables GPS
		if (!Input.location.isEnabledByUser) 
		{
			Debug.Log ("User has not enabled GPS");
			yield break;
		}

		//Start GPS
		Input.location.Start ();

		int maxWait = 20;

		//Wait for GPS to initialize
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) 
		{
			yield return new WaitForSeconds (1);
			maxWait--;
		}

		//Check for time out
		if (maxWait <= 0) 
		{
			Debug.Log ("Timed out");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed) 
		{
			Debug.LogFormat ("Unable to determine device location");
			yield break;
		}

		//get location from device
		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		yield break;
	}

	private IEnumerator UpdateLocation(){
		//get location from device
		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		yield break;
	}
}
