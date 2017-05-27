using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolObjectsTransform : MonoBehaviour {

    private bool _toUp = true;
    private float _yPoint;
	// Use this for initialization
	void Start () {
        _yPoint = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

        if (_toUp)
            _yPoint += Time.deltaTime/10;
        else
            _yPoint -= Time.deltaTime/10;

        if (_yPoint < 0)
            _toUp = true;
        else if (_yPoint > 4)
            _toUp = false;

        transform.position = new Vector3(transform.position.x,
                                          _yPoint,
                                          transform.position.z);
	}
}
