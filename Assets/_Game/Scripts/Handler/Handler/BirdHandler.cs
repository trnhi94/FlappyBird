using System.Collections;
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

    public void Controller()
    {
        #region MOVING

        _velocityY += Constants.Gravity * Time.deltaTime;
        transform.position += Vector3.up * _velocityY * Time.deltaTime; ;
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger(Constants.Flappy);
            _velocityY = Constants.JumpForce;
            AudioController.Instance.PlaySfx(Constants.SFXWing);
        }

        #endregion
        #region COLLISION

        CheckCollide();
        if(!_isScore)
        {
            CheckScore();
        }

        #endregion
    }

    private void CheckCollide()
    {
        var _colliders = _collider.GetCollisions();
        foreach (var other in _colliders)
        {
            if (other.gameObject.layer == Constants.Obstacle)
            {
                _velocityY = 0f;
                AudioController.Instance.PlaySfx(Constants.SFXHit);
                GameController.Instance.State = GameState.EndGame;
                GameController.Instance.CheckGameState();
                break;
            }
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
                GameController.Instance.Score++;
                UIController.Instance.UpdateScore(GameController.Instance.Score);
                AudioController.Instance.PlaySfx(Constants.SFXPoint);
                StartCoroutine(ResetCheckScore());
            }
        }
    }

    IEnumerator ResetCheckScore()
    {
        yield return new WaitForSeconds(0.5f);
        _isScore = false;
    }
}
