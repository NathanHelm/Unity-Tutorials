using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DropTheBallLearnPosition : MonoBehaviour
{
    Rigidbody rb;
    float distance = 200;
    public void Start()
    {
        //IMPORTANT
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Launch());
    }
    public IEnumerator Launch()
    {
        while (true)
        {
            rb.useGravity = false; //gameobject's gravity is disabled
            rb.AddForce(new Vector2(0, distance)); //object's force moves object up
            yield return new WaitForSeconds(2); //wait 2 seconds
            rb.useGravity = true; //enable gravity, object goes down.
            yield return new WaitUntil(() => transform.position.y <= 0); //wait until y position reach 0 (initial position)
            rb.linearVelocity = new Vector3(0, 0, 0); //stop velocity
            yield return null;
        }

    }
}