using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRigidbody;//player's rigidbody
    public int speed = 6;
    Vector3 moveMent;
    Animator playerAC;
    //floor
    LayerMask floorMask;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        playerAC = GetComponent<Animator>();

        floorMask = LayerMask.GetMask("Floor");
    }
 
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        //player move 
        move(h,v);
        //animation detector
        animating(h,v);
        turning();

    }
    void move(float h, float v)
    {
        moveMent.Set(h,0f, v);
        moveMent = moveMent.normalized*speed*Time.deltaTime*-1;
        playerRigidbody.MovePosition(transform.position+moveMent);
    }
    void animating(float h, float v)
    {
        //if h or v not equial to 0 
        bool walking = h != 0 || v != 0;
        
        playerAC.SetBool("IsWalking", walking);

    }
    void turning()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay( Input.mousePosition);
        RaycastHit cameraHit;
        if(Physics.Raycast( cameraRay,out cameraHit,100f,floorMask ))
        {
            Vector3 playerToMouse = cameraHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newQuaternion = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newQuaternion);
        }
    }
}
   