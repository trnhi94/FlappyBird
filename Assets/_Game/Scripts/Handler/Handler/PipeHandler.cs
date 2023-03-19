using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHandler : MonoBehaviour
{
    public float duration = 1.5f;

    //markers
    public GameObject minYMarker;
    public GameObject maxYMaker;

    private float elapsedTime;

    private float minY;
    private float maxY;

    System.Random rand = new System.Random();

    //// Start is called before the first frame update
    void Start()
    {
        minY = minYMarker.transform.position.y;
        maxY = maxYMaker.transform.position.y;

        var randY = minY + (maxY - minY) * (float)rand.NextDouble();
        GameObject pipe = ObjectPooling.Instance.GetPooledObject();
        if (pipe != null)
        {
            pipe.transform.position = new Vector3(5f, randY, 0f);
            pipe.SetActive(true);
        }
    }
    public void SpawnPipe()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= duration)
        {
            var randY = minY + (maxY - minY) * (float)rand.NextDouble();
            GameObject pipe = ObjectPooling.Instance.GetPooledObject();
            if (pipe != null)
            {
                pipe.transform.position = new Vector3(5f, randY, 0f);
                pipe.SetActive(true);
            }

            elapsedTime = 0f;
        }
    }
}
