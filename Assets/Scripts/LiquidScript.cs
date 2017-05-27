using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidScript : MonoBehaviour {

    public GameObject tester0;
    public GameObject tester1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == tester0)
        {
            transform.parent = tester0.transform;
        }

        else if (collision.gameObject == tester1)
        {
            transform.parent = tester1.transform;
        }
    }
}
