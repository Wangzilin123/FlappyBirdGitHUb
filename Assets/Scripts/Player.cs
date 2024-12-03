using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbodyBied;
    public Animator animator;
    private bool death = false;

    public delegate void DeathNotify();

    public event DeathNotify onDeath;
    private Vector3 initpos;

    public UnityAction<int> OnScore;

    public void Init()
    {
        transform.position = initpos;
        animator.applyRootMotion = false;
        transform.eulerAngles = Vector3.zero;
        Idle();
    }
    void Start()
    {
        this.Idle();
        initpos = transform.position;
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
        rigidbodyBied.AddForce(new Vector2(0, 230f), ForceMode2D.Force);
    }
    public void Idle()
    {
        death = false;
        this.rigidbodyBied.Sleep();
        rigidbodyBied.simulated = false;
        this.animator.SetTrigger("Idle");
    }
    public void Fly()
    {
        this.rigidbodyBied.WakeUp();
        rigidbodyBied.simulated = true;
        this.animator.SetTrigger("Fly");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
    public void Die()
    {
        death = true;
        if (onDeath != null)
        {
            onDeath();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (OnScore != null)
        {
            OnScore(1);
        }
    }
}
