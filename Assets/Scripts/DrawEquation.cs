using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawEquation : MonoBehaviour {

    public float radius;
    public float speed;
    public Transform[] points;
    public float _xPoint;
    public float _yPoint;
    private float _zPoint;

    private bool _sinToLeft = false;
    private bool _helixToUp = false;
    public int _trianglePoint = 0;
    
    public enum Equation
    {
        Circle,
        Sin,
        Helix,
        Triangle
};

    public Equation equation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (equation)
        {
            case Equation.Circle:
                _DrawCircle();
                break;

            case Equation.Sin:
                _DrawSin();
                break;

            case Equation.Helix:
                _DrawHelix();
                break;

            case Equation.Triangle:
                _DrawTriangle();
                break;
        }
	}

    private void _DrawCircle()
    {
        _xPoint = radius * Mathf.Cos(Time.time * speed);
        _yPoint = radius * Mathf.Sin(Time.time * speed);
        _zPoint = transform.localPosition.z;

        transform.localPosition = new Vector3(_xPoint, _yPoint, _zPoint);
    }

    private void _DrawSin()
    {   
        if (_sinToLeft)
            _xPoint += Time.deltaTime;
        else
            _xPoint -= Time.deltaTime;

        if (_xPoint < -8)
            _sinToLeft = true;
        else if (_xPoint > 8)
            _sinToLeft = false;

        _yPoint = radius * Mathf.Cos(_xPoint);
        _zPoint = transform.localPosition.z;

        transform.localPosition = new Vector3(_xPoint/2, 
                                              _yPoint, 
                                              _zPoint);
    }

    private void _DrawHelix()
    {
        _xPoint = radius * Mathf.Cos(Time.time * speed) - 2;

        if (_helixToUp)
            _yPoint += Time.deltaTime;
        else
            _yPoint -= Time.deltaTime;

        if (_yPoint > 2.5)
            _helixToUp = false;
        else if (_yPoint < -2.5)
            _helixToUp = true;

        _zPoint = radius * Mathf.Sin(Time.time * speed);
        transform.localPosition = new Vector3(_xPoint, _yPoint, _zPoint);
    }

    private void _DrawTriangle()
    {
        if (transform.position == points[0].position)
            _trianglePoint = 1;
        else if (transform.position == points[1].position)
            _trianglePoint = 2;
        else if (transform.position == points[2].position)
            _trianglePoint = 0;

        if (_trianglePoint == 0)
        {
            iTween.MoveTo(gameObject,
                    iTween.Hash(
                        "position", points[0].position,
                        "time", 1F,
                        "easetype", "linear"
                        )
                    );
        }
        else if (_trianglePoint == 1)
        {
            iTween.MoveTo(gameObject,
                    iTween.Hash(
                        "position", points[1].position,
                        "time", 1F,
                        "easetype", "linear"
                        )
                    );
        }
        
        else if (_trianglePoint == 2)
        {
            iTween.MoveTo(gameObject,
                    iTween.Hash(
                        "position", points[2].position,
                        "time", 1F,
                        "easetype", "linear"
                        )
                    );
        }

    }
}
