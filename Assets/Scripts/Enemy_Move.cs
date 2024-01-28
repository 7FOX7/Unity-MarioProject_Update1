using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public float enemySpeed = 4f;
    private int moveX = 1; 
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(moveX, 0)); 
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, 0) * enemySpeed;
        if(hit.distance < 1.5f)
        {
            Flip(); 
        }
    }
    
    void Flip()
    {
        if(moveX > 0)
        {
            moveX = -1; 
        }
        else
        {
            moveX = 1; 
        }
    }
}
