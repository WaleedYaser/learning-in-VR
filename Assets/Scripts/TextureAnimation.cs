using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimation : MonoBehaviour {

    public float speedDownFactor;

    private Material _material;
    private Vector2  _offset;
    private float _x = 0;
    private float _y = 0;


	// Use this for initialization
	void Start () {
        _material = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        _x = (_x + Time.deltaTime) % (speedDownFactor * 2);
        _y = (_y + Time.deltaTime) % speedDownFactor;
        _offset = new Vector2(_x / (speedDownFactor * 2),
                              _y / speedDownFactor);
        _material.SetTextureOffset("_MainTex", _offset);
	}
}
