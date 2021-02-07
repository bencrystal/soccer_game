using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badBallFollower : MonoBehaviour
{

    public Transform ball;
    private Rigidbody2D rb;
    public float moveSpeed = 3.0f;
    private Vector2 movement;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = ball.position - transform.position;

        // ROTATES SPRITE TO FOLLOW BALL, BUT WE ACTUALLY WANT DIFFERENT SPRITES
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;

        direction.Normalize();
        movement = direction;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

}
