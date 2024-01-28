using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessCollision(collision.gameObject); 
    }

    void ProcessCollision(GameObject collider)
    {
        if(collider.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody2D>().transform.Rotate(0, 0, 90);
        }
    }

    // 2. if any of the objects hits another object; 
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Rigidbody body = hit.collider.attachedRigidbody; 

    //    // if there is no rigid body or it is kinematic
    //    if(body == null || body.isKinematic)
    //    {
    //        return; 
    //    }
    //    if (hit.gameObject.name == "Player")
    //    {
    //    }
    //}

    // 1. rotates the object (which is supposed to be an obstacle) 
    void Falling()
    {
        //Quaternion localRotation = gameObject.transform.rotation;
        //localRotation.y *= 90;
        //transform.localRotation = localRotation; 
        transform.Rotate(Vector2.up * Time.deltaTime); 

    }


    // 3. we are just creating the instance of the controllerColliderHit
}
