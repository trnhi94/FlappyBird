using System.Windows;
using System.Collections.Generic;
using UnityEngine;

public class Collide2D : MonoBehaviour
{
    [SerializeField] private Vector2 size = Vector2.one;
    public float Top => transform.position.y + (size.y / 2f);
    public float Bottom => transform.position.y - (size.y / 2f);
    public float Left => transform.position.x - (size.x / 2f);
    public float Right => transform.position.x + (size.x / 2f);

    private static List<Collide2D> allCollides = new List<Collide2D>();

    private void Awake()
    {
        allCollides.Add(this);
    }

    private void Update()
    {
        if(GetCollisions().Count > 0)
        {
            Debug.Log("Collision!!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void OnDestroy()
    {
        allCollides.Remove(this);
    }

    public List<Collide2D> GetCollisions()
    {
        return allCollides.FindAll((collide) =>
        {
            if (collide == this)
                return false;

            return !(Right <= collide.Left || Left >= collide.Right || Top <= collide.Bottom || Bottom >= collide.Top);
        });
    }
}
