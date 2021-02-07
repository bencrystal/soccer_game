using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator animator;

    bool isKicking = false;

    public float thrust = 1.0f;


    // Update is called once per frame
    void Update()
    {
        //receive input

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    private void FixedUpdate()
    {
        //physics and movement

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //kick(); //kick other players or ball to clear corners

    }


    //kick other players or ball to clear corners
    private IEnumerator kick()
    {
        if (isKicking = true){
            //return null;

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                isKicking = true;
                rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);

                yield return new WaitForSeconds(1);
                isKicking = false;
            }
        }
    }

}
