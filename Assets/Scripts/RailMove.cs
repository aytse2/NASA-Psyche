using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject AsteroidSpawner;
    public float velocity;// in units per second
    public float distanceTraveled;
    private int lastSpawn;
    void Start()
    {
        distanceTraveled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += velocity * Time.deltaTime;
        player.transform.Translate(player.transform.position.x, player.transform.position.y, player.transform.position.z + velocity * Time.deltaTime);
        if(Mathf.Floor(distanceTraveled) % 100 == 0 && Mathf.Floor(distanceTraveled) % 100 != lastSpawn)
        {
            lastSpawn = (int) Mathf.Floor(distanceTraveled);
            Instantiate(AsteroidSpawner, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 20), Quaternion.identity);
        }
    }
}
