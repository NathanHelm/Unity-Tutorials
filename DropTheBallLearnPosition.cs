using System.Collections;
using UnityEngine;

public class DropTheBallLearnPosition : MonoBehaviour
{
    Rigidbody rb; //#1 our component variable, the component is a rigidbody
    float distance = 200; 
    public void Start()
    {
        //IMPORTANT
        rb = GetComponent<Rigidbody>(); //#2 
        StartCoroutine(Launch()); //run coroutine
    }
    public IEnumerator Launch() //creating a coroutine requires the IEnumerator type
    {
        while (true) //#9 our coroutine is stuck in an infinite loop. This is fine with because we delay each iteration of this code. The delay occurs on comment #7 
        {
            rb.useGravity = false; //#3 gameobject's gravity is disabled
            rb.AddForce(new Vector2(0, distance)); //#4 object's force moves object up
            yield return new WaitForSeconds(2); //#5 DELAY: wait 2 seconds
            rb.useGravity = true; //#6 enable gravity, object goes down.
            yield return new WaitUntil(() => transform.position.y <= 0); //#7 DELAY: wait until the y position reaches 0 (initial position)
            rb.linearVelocity = new Vector3(0, 0, 0); //#8 stop velocity
            yield return null;
        }

    }
}