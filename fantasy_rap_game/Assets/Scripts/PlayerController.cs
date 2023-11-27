/*
 * Name: Jackson Miller
 * Date: 9/27/23
 * Desc: Attach to allow player to control with WASD or arrow keys (Animation will be added later)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Class variables
    [Tooltip("How fast does the player move?")]
    public float speed = 70;

    private Rigidbody2D myRB;
    private Animator myAnim;
    private SpriteRenderer myRenderer;

    public FollowCamera followCam;
    public float shakeAmount = 5.0f;
    public float shakedur = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Take rigidbody2D component from the GameObject this is attached to if it has it.
        myRB = GetComponent<Rigidbody2D>();
        // This only works because there is a single camera, otherwise you might have to set it.
        followCam = GameObject.FindObjectOfType<FollowCamera>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;

        // Check for 2D input (WASD/Arrows using the Axes system)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // handles animations for player sprite
        myAnim.SetFloat("x", movement.x);
        myAnim.SetFloat("y", movement.y);
        if(movement.x < 0)
            myRenderer.flipX = true;
        else
            myRenderer.flipX = false;

        movement.Normalize();
        myRB.AddForce(movement * speed);

        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    followCam.StartShake(shakedur, shakeAmount);
        //}
    }
}
