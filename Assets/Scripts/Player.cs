using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbodyBied;
    public Animator animator;
    private bool death = false;
    void Start()
    {
        this.Idle();
    }

    void Update()
    {
        if (death)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Jump();
            }
        }

    }
    void Jump()
    {
        rigidbodyBied.velocity = Vector2.zero;
        rigidbodyBied.AddForce(new Vector2(0,230f),ForceMode2D.Force);
    }
    public void Idle()
    {
        this.rigidbodyBied.Sleep();
        this.animator.SetTrigger("Idle");
    }
    public void Fly()
    {
        this.rigidbodyBied.WakeUp();
        this.animator.SetTrigger("Fly");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
    public void Die()
    {
        death = true;
    }
}
