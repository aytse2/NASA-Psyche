using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float controlSpeed = 13f;
    [Tooltip("In ms")] [SerializeField] float xRange = 12f;
    [Tooltip("In ms")] [SerializeField] float yRange = 7f;
    [SerializeField] GameObject[] guns;
    [SerializeField] GameObject[] gunsVisualEffect;

    [Header("Control Moving Position")]
    [SerializeField] float positionPitchFactor = -1.61f;
    [SerializeField] float positionYawFactor = 1.8f;

    [Header("Control Moving Natural")]
    [SerializeField] float controlPitchFactor = -18.3f;
    [SerializeField] float controlYawFactor = 9.6f;
    [SerializeField] float controlRollFactor = -28.3f;

    [Header("Other Settings")]
    [SerializeField] bool isControlEnabled = true;
    float xThrow;
    float yThrow;
    
    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            
        }
    }

    private void ProcessRotation()
    {
        float pitchDueToControllThrowY = yThrow * controlPitchFactor;//this add on the extra movement to the ship when movement it, to make it have more netural movement 
        float pitchDueToControllThrowX = xThrow * controlYawFactor;
        float pitchDueToControllThrowZ = xThrow * controlRollFactor;
        float pitch = transform.localPosition.y * positionPitchFactor + pitchDueToControllThrowY, //localPosition.y is interacting with positionPitchFactor, that why positionPitchFactor has to be negative, when y is positive, ship look down, when negative the ship look up
            yaw = transform.localPosition.x * positionYawFactor + pitchDueToControllThrowX, 
            roll = pitchDueToControllThrowZ;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); //Quaternion.Euler(   x ,  y ,  z  )
                                                                     //Quaternion.Euler(pitch, yaw, roll)
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");//we use this to access edit->project setting -> inputmanager -> axes
                                                                 //to adopt the control for all kind of input such as keyboard, game controller...etc
                                                                 //x indicates horizontal movement, throw indicates away from center
                                                                 // Start is called before the first frame update
        float xOffset = xThrow * controlSpeed * Time.deltaTime;//xOffsetThisFrame * frame rate per second will tell us the moving controlSpeed horizontal wise per second
        //setting movement for x line---------------------------------------
        float rawNewXPos = transform.localPosition.x + xOffset;
        float calmpedX = Mathf.Clamp(rawNewXPos, -xRange, xRange);//this method will constrains rawNewXPos between -5 to 5
        transform.localPosition = new Vector3(calmpedX, transform.localPosition.y, transform.localPosition.z);
        //------------------------------------------------------------------
        //setting movement for y line
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawNewYPos = transform.localPosition.y + yOffset;
        float calmpedY = Mathf.Clamp(rawNewYPos, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, calmpedY, transform.localPosition.z);
    }
}
