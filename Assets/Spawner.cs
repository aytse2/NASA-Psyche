using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2f;
    private Vector3 startPos;
    public GameObject asteroidPrefab;
    public float lastAsteroidTime = -100f;
   
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;

        if (Time.time - lastAsteroidTime > 1f)
        {
            lastAsteroidTime = Time.time;
            GameObject asteroid = Instantiate(asteroidPrefab);
            asteroid.transform.position = transform.position + transform.forward;
            asteroid.GetComponent<Rigidbody>().velocity = transform.forward * -10;
        }

    }
}
