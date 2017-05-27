using UnityEngine;
using System.Collections;

public class WaypointMovement : MonoBehaviour {
	
	public GameObject player;


	public float height = 2;
	public bool teleport = true;

	public float maxMoveDistance = 10;

    public GvrAudioSource playerAudioSource;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(GameObject waypoint) {
		if (!teleport) {
			iTween.MoveTo (player, 
				iTween.Hash (
					"position", new Vector3 (waypoint.GetComponent<Transform> ().position.x, height, waypoint.GetComponent<Transform> ().position.z), 
					"time", .2F, 
					"easetype", "linear"
				)
			);
		} else {
			player.transform.position = new Vector3 (waypoint.GetComponent<Transform> ().position.x, height, waypoint.GetComponent<Transform> ().position.z);
		}
        playerAudioSource.clip = waypoint.GetComponent<GvrAudioSource>().clip;
        playerAudioSource.Play();
	}

}

