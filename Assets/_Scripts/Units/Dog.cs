using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float moveSpeed = 2f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 direction;



       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
        direction = UpdateDirection(direction);
        UpdateAnimator(animator, direction);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }

    Vector2 UpdateDirection(Vector2 _direction)
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        return _direction;
    }

    void UpdateAnimator(Animator _animator, Vector2 _direction)
    {
        _animator.SetFloat("Horizontal", _direction.x);
        _animator.SetFloat("Vertical", _direction.y);
        _animator.SetFloat("Speed", _direction.sqrMagnitude);
    }

    void PlayerControl()
    {
        var isRunning = Input.GetKeyDown(KeyCode.LeftShift);

        if(isRunning)
        {
            moveSpeed = 5;
        }

        else
        {
            moveSpeed = 2;
        }
    }

}
