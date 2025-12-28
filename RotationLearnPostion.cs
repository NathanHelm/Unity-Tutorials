using System;
using System.Diagnostics;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RotationLearnPosition : MonoBehaviour
{
    [SerializeField]
    private float rotSpeed;
    float y = 0;
    float x = 0;
    public void Update()
    {
        //#1 this should look familiar.
        y += rotSpeed * Time.deltaTime;
        //#2 because eulerAngles have a range of 0,360 if the angle is > 360, we'll simply set it to zero
        y = (y > 360) ? 0 : y;



        //still inside update
        x += rotSpeed * Time.deltaTime * 2; //#3 x will rotate twice as hard.
        x = (x > 360) ? 0 : x;

        transform.eulerAngles = new Vector3(x, y, 0); //eulerAngles changes the rotation.
    }
}