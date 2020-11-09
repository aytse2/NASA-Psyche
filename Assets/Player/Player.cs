using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float displacement = Input.GetAxis("Horizontal") * 0.1f;

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * -displacement);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * displacement);

    }
}
