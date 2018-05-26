using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class WandererController : MonoBehaviour {

    public bool canMove = true;
    public bool isInteracting = false;
    float x;
    public float speed = 5;
    public Rigidbody2D rb;
    public Transform transform;
    public SkeletonAnimation skeletonAnimation;
    private string currentAnimationName;

    void OnTriggerEnter2D(Collider2D other)
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {

    }

    private void Update()
    {

        if (canMove == true)
        {

            x = Input.GetAxis("Horizontal") * speed;
            rb = GetComponent<Rigidbody2D>();
            if (x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                SetAnimation("Walk_test");
            }
            else if (x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                SetAnimation("Walk_test");
            }
            else
            {
                SetAnimation("Idle");
            }
        }
        else
        {
            x = Input.GetAxis("Horizontal") * 0;
            SetAnimation("Idle");
        }
    }

    public void SetCanMove(bool movable)
    {
        canMove = movable;
    }

    private void SetAnimation(string name)
    {

        if (name == currentAnimationName)
            return;

        skeletonAnimation.state.SetAnimation(0, name, true);
        currentAnimationName = name;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x, rb.velocity.y);
        // you use these for physics
    }
}
