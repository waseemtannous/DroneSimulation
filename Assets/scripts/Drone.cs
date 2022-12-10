using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private float speed = 5.0f;

    private bool wPressed = false;
    private bool sPressed = false;
    private bool aPressed = false;
    private bool dPressed = false;

    // get dimensions of "floor" object
    private float floorWidth = GameObject.Find("floor").GetComponent<Renderer>().bounds.size.x;
    private float floorLength = GameObject.Find("floor").GetComponent<Renderer>().bounds.size.z;

    private DroneMovements droneMovements = new DroneMovements();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get dimensions of "floor" object
        float floorWidth = GameObject.Find("floor").GetComponent<Renderer>().bounds.size.x;
        float floorLength = GameObject.Find("floor").GetComponent<Renderer>().bounds.size.z;

        // get position of drone
        float droneX = transform.position.x;
        float droneZ = transform.position.z;

        // move drone with w a s d keys and check if drone is within bounds of floor
        if (Input.GetKey(KeyCode.W) && droneZ < floorLength / 2)
        {
            wPressed = true;
            // droneMovements.wPressed = true;
        }
        if (Input.GetKey(KeyCode.S) && droneZ > -floorLength / 2)
        {
            sPressed = true;
            // droneMovements.sPressed = true;
        }
        if (Input.GetKey(KeyCode.A) && droneX > -floorWidth / 2)
        {
            aPressed = true;
            // droneMovements.aPressed = true;
        }
        if (Input.GetKey(KeyCode.D) && droneX < floorWidth / 2)
        {
            dPressed = true;
            // droneMovements.dPressed = true;
        }

        // if space is pressed then land drone
        if (Input.GetKey(KeyCode.Space))
        {
            // droneMovements.landDrone();
        }
    }

    private void FixedUpdate() {
        // check if w a s d are pressed and move accordingly
        if (wPressed)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            droneMovements.sendCommand();
            wPressed = false;
            // droneMovements.wPressed = false;
        }
        if (sPressed)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            droneMovements.sendCommand();
            sPressed = false;
            // droneMovements.sPressed = false;
        }
        if (aPressed)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            droneMovements.sendCommand();
            aPressed = false;
            // droneMovements.aPressed = false;
        }
        if (dPressed)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            droneMovements.sendCommand();
            dPressed = false;
            // droneMovements.dPressed = false;
        }
        
    }
}
