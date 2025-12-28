using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LearnPosition : MonoBehaviour 
{
    [SerializeField] //#1 using serialize Field, our variable can be seen in the inspector (see image glossary if you forget where that is!)
    private float speed = 1; 
    private float posY;
    public void Update()
    {
        //#2 here we are increasing the y position by speed * Time.deltaTime every frame. 
        posY += speed * Time.deltaTime;
        //#3 What is Time.deltaTime? From unity: Time.deltaTime is the interval in seconds from the last frame to the current one.
        //#4 what is transform.position? --> the position of gameobject we attach this script to.
        posY = Mathf.Min(7, posY);
        //#5 we are clamping the position to 7. Using Mathf.Min means that if our position exceeds 7, it still remains 7
        // #6 its important to know that we can't directly change the y position by our yPos variable like in line 23.
        // transform.position.y = posY; // #7 this is because the 'y' in transform.position.y is a privately set variable. 
        //#8 because line 23 can't be performed, we must make a new vector and set the x, y, and z positioning. 
        transform.position = new Vector3(transform.position.x, posY, 0); 
    } 
    
}
