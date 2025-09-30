using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LearnPosition : MonoBehaviour
{
    [SerializeField] //variable can be seen in the inspector (see image glossary if you forget where that is!)
    private float speed = 1; //speed in seconds 
    private float posY;
    public void Update()
    {
        posY += speed * Time.deltaTime;
        //increasing the y position. what else can we change? 
        //from unity: Time.delta time The interval in seconds from the last frame to the current one
        //what is transform.position? --> the position of gameobject we attach this script to

        //we'll also clamp the position
        posY = Mathf.Min(7, posY);

        transform.position = new Vector3(transform.position.x, posY, 0);
        
      
      

    } 
    
}
