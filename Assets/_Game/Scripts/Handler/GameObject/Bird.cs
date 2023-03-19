using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Vector2 startPos;
    private Animator anim;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = 9.8f;
    private float velocityY;
    private Collide2D collider;
    private bool _isDead =  false;
    public bool IsDead  => _isDead;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collide2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        velocityY -= gravity * Time.deltaTime;
        transform.position += Vector3.up * velocityY * Time.deltaTime;

        //if (transform.position.y <= 0)
        //{
        //    velocityY = 0;
        //    transform.position = new Vector3(transform.position.x, 0, 0);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Flappy");
            velocityY = jumpForce;
        }

        CheckCollide();
    }

    private void CheckCollide()
    {
        var colliders = collider.GetCollisions();

        foreach (var other in colliders)
        {
            if(other.gameObject.layer == 7)
            {
                this.transform.position = new Vector3(0f, other.Top, 0f);
                _isDead = true;
                GameController.Instance.EndGame();
            }
        }
    }
}
