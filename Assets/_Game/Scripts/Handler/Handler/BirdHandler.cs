using System.Collections.Generic;
using UnityEngine;

public class BirdHandler : MonoBehaviour
{
    public Vector2 startPos;
    private Animator _anim;
    private float _velocityY;
    private Collide2D _collider;
    private bool _isScore = false;

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
        if(!_isScore)
        {
            CheckScore();
        }
    }

    private void CheckCollide()
    {
        var _colliders = _collider.GetCollisions();
        foreach (var other in _colliders)
        {
            if (other.gameObject.layer == Constants.Obstacle)
            {
                _velocityY = 0f;
                GameController.Instance.State = GameController.GameState.EndGame;
                GameController.Instance.CheckGameState();
                break;
            }

            //if (other.gameObject.layer == Constants.Score)
            //{
            //    Debug.Log("Score!!!");
            //    GameController.Instance.Score++;
            //    UIController.Instance.UpdateScore(GameController.Instance.Score);
            //}
        }
    }

    private void CheckScore()
    {
        var _colliders = _collider.GetCollisions();
        foreach (var other in _colliders)
        {
            if (other.gameObject.layer == Constants.Score && !_isScore)
            {
                _isScore = true;
                Debug.Log("Score!!!");
                GameController.Instance.Score++;
                UIController.Instance.UpdateScore(GameController.Instance.Score);
            }
        }
    }
}
