using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public GameObject[] backgrounds;
    public float backgroundSize;
    [SerializeField] private float speed;

    private void Update()
    {
        if (GameController.Instance.State != GameController.GameState.PlayGame)
            return;
        transform.position -= Vector3.right * Time.deltaTime * speed;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            var item = backgrounds[i];
            var position = item.transform.position;
            var leftPosition = Camera.main.ScreenToWorldPoint(Vector2.zero);
            if(item.transform.position.x + backgroundSize/2f < leftPosition.x)
            {
                position.x += backgroundSize * backgrounds.Length;
                item.transform.position = position;
            }
        }
    }
}