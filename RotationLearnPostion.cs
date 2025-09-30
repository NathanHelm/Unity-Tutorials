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
        //part 1
        y += rotSpeed * Time.deltaTime;
        y = (y > 360) ? 0 : y;
        //part 2
        x += rotSpeed * Time.deltaTime * 2; //x will run twice as hard
        x = (x > 360) ? 0 : x;
        transform.eulerAngles = new Vector3(x, y, 0);
    }
}