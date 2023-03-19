using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        #region MOVING
        if (GameController.Instance.State != GameController.GameState.PlayGame)
            return;

        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime,
                                        transform.position.y);

        if (this.transform.position.x < Constants.DestroyZone)
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}
