using UnityEngine;

public class SinWaveLearnPosition : MonoBehaviour
{
    //our second learn position
    [SerializeField]
    private float freq = 1f;
    [SerializeField]
    private float amp = 1.5f;
    private float angle;
    public void Update()
    {
        angle += amp * Time.deltaTime; 
        transform.position = new Vector3(transform.position.x, Mathf.Sin(angle) * amp, 0);
    } 


   
    
}
