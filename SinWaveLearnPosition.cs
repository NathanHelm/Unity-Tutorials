using UnityEngine;

public class SinWaveLearnPosition : MonoBehaviour
{
    [SerializeField]
    private float freq = 1f; //the speed at which the wave changes
    [SerializeField]
    private float amp = 1.5f; //the size of the wave
    private float angle;
    public void Update()
    {
        //#1 increment the angle!
        angle += amp * Time.deltaTime;

        //formula for sin wave!
        float sinWave = Mathf.Sin(angle * freq) * amp; 
        //#2 update the position!
        transform.position = new Vector3(transform.position.x, sinWave, 0);
    } 


   
    
}
