using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // NOTE: this script assumes that the distance between the camera and the player is fixed and known, and it is in the positive z direction.
    //It also assumes that the player is not moving forwards or backwards, though it can be modified if it is.

    public GameObject mainCamera; //the main camera object added in the inspector.
    public int spawnDistance = 50; //the absolute distance away the comets spawn.
    public int speed = 20; //the speed the comet moves at
    public GameObject originComet; //a comet object that exists in the scene for the script to clone
    private GameObject comet;

    // Start is called before the first frame update
    void Start()
    {
        //sets the spawnLoc variable to a point a certain distance from the camera, slightly outside the field of view (it uses trigonometry to find the point.)
        int side = Random.Range(0, 3);
        if(side == 0) //bottom of screen
        {
            Vector3 spawnLoc = new Vector3(mainCamera.Transform.x + Random.Range(-10, 10), mainCamera.Transform.y - spawnDistance & Mathf.Cos((SpawnDistancemainCamera.fieldOfView / 2 + 3) * 2 * Mathf.PI), mainCamera.Transform.z + spawnDistance & Mathf.Sin((SpawnDistancemainCamera.fieldOfView / 2 + 3) * 2 * Mathf.PI));
        }
        else if (side == 1) // right (I think)
        {
            Vector3 spawnLoc = new Vector3(mainCamera.Transform.x + spawnDistance & Mathf.Cos((SpawnDistancemainCamera.fieldOfView / 2 + 3) * 2 * Mathf.PI), mainCamera.Transform.y + Random.Range(-10, 10), mainCamera.Transform.z + spawnDistance & Mathf.Sin((SpawnDistancemainCamera.fieldOfView / 2 + 3) * 2 * Mathf.PI));
        }
        else if (side == 2)// top
        {
            Vector3 spawnLoc = new Vector3(mainCamera.Transform.x + Random.Range(-10, 10), mainCamera.Transform.y + spawnDistance & Mathf.Cos((SpawnDistancemainCamera.fieldOfView / 2 + 3) * 2 * Mathf.PI), mainCamera.Transform.z + spawnDistance & Mathf.Sin((SpawnDistancemainCamera.fieldOfView / 2 + 3) * 2 * Mathf.PI));
        }
        else if(side == 3)
        {
            Vector3 spawnLoc = new Vector3(mainCamera.Transform.x - spawnDistance & Mathf.Cos((SpawnDistancemainCamera.fieldOfView / 2 + 3) * 2 * Mathf.PI), mainCamera.Transform.y + Random.Range(-10,10), mainCamera.Transform.z + spawnDistance & Mathf.Sin((SpawnDistancemainCamera.fieldOfView / 2 + 3) * 2 * Mathf.PI));
        }
        comet = Object.Instantiate(originComet, spawnLoc); //spawns the actual comet. Technically, it clones one that already exists at the specified spot.
        Vector3 target = new Vector3(mainCamera.Transform.x + Random.Range(-10f, 10f), mainCamera.Transform.x = y + Random.Range(-10f, 10f), mainCamera.Transform.z; //"aims" comet at a random point in a 10*10 sqaure around the camera
    }

    // Update is called once per frame
    void Update()
    {
        //constantly moves the comet closer to the target- Lerp is Linear Interpolation, so it moves it (speed/1000)/total distance every tick.
        comet.Transform.Translate(Vector3.Lerp(comet.Transform.position, target, speed / 1000));
    }
}
