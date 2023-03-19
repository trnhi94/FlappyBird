using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHandler : MonoBehaviour
{
    public Vector2 startPos;
    private Animator _anim;
    private float _velocityY;
    private Collide2D _collider;

    // Start is called before the first frame update
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _collider = GetComponent<Collide2D>();
    }

    public void Movement()
    {
        _velocityY += Constants.Gravity * Time.deltaTime;
        transform.position += Vector3.up * _velocityY * Time.deltaTime; ;
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger(Constants.Flappy);
            _velocityY = Constants.JumpForce;
        }

        CheckCollide();
    }

    private void CheckCollide()
    {
        if (GameController.Instance.State != GameController.GameState.PlayGame)
            return;

        var colliders = _collider.GetCollisions();

        foreach (var other in colliders)
        {
            if (other.gameObject.layer == Constants.Obstacle)
            {
                _velocityY = 0f;
                GameController.Instance.State = GameController.GameState.EndGame;
                GameController.Instance.CheckGameState();
            }
        }
        var collidersEnter = _collider.GetCollisionEnter();
        foreach (var other in colliders)
        {
            if (other.gameObject.layer == Constants.Score)
            {
                Debug.Log("Score!!!");
                GameController.Instance.Score++;
                UIController.Instance.UpdateScore(GameController.Instance.Score);
            }
        }
    }
}
