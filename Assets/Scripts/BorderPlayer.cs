using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//implementation of a workspace for the player
public class BorderPlayer : MonoBehaviour
{

    float distance;
    float  _leftBorder;
    float _rightBorder;
    float _topBorder;
    float _bottomBorder;


    void Start()
    {
        // calculate each side of the camera to be used 
        Vector3 pos1 = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 pos2 = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0f, distance));
        Vector3 pos3 = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, distance));
        Vector3 pos4 = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0f, distance));

        //position assignment 
        _leftBorder = pos1.x;
        _rightBorder = pos2.x;
        _topBorder = pos3.y;
        _bottomBorder = pos4.y;
    }



    void Update()
    {
        // set a boundary so that the player cannot go beyond it
        Vector3 pos = transform.position;
        transform.position = new Vector3(Mathf.Clamp(pos.x, _leftBorder, _rightBorder), Mathf.Clamp(pos.y, _bottomBorder, _topBorder), pos.z);
    }
}
