using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;

// use package to encode string in utf-8
using System.Text;

public class Drone : MonoBehaviour
{

    private UdpClient client;

    private string droneIP = "192.168.10.1";
    private int dronePort = 8889;
    // private string droneIP = "127.0.0.1";
    // private int dronePort = 65432;

    // speeds for drone movements
    private const float DroneSpeed = 60.0f;
    private const float speed = 5.0f;

    private bool wPressed = false;
    private bool sPressed = false;
    private bool aPressed = false;
    private bool dPressed = false;

    private bool upPressed = false;
    private bool downPressed = false;
    private bool leftPressed = false;
    private bool rightPressed = false;

    private bool flying = false;

    Socket droneSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

    // Start is called before the first frame update
    void Start()
    {
        droneSocket.Connect(droneIP, dronePort);
        sendCommand("command");
        // sendCommand("takeoff");
        // sleep for 5 seconds

        // // get drone video stream
        sendCommand("streamoff");
        sendCommand("streamon");

        // display video stream in unity using udp
        // GameObject.Find("VideoPlayer").GetComponent<UnityEngine.Video.VideoPlayer>().url = "udp://@" + videoIP + ":" + videoPort;

    }

    bool checkDronePosition(){
        // get dimensions of "floor" object
        float floorWidth = GameObject.Find("floor").GetComponent<Renderer>().bounds.size.x;
        float floorLength = GameObject.Find("floor").GetComponent<Renderer>().bounds.size.z;

        // get position of drone
        float droneX = transform.position.x;
        float droneZ = transform.position.z;

        // check if drone is within bounds of floor
        return droneZ <= floorLength / 2 && droneZ >= -floorLength / 2 && droneX >= -floorWidth / 2 && droneX <= floorWidth / 2;
    }

    bool checkEdge() {
        // check if drone is at edge of floor
        // get dimensions of "floor" object
        float floorWidth = GameObject.Find("floor").GetComponent<Renderer>().bounds.size.x;
        float floorLength = GameObject.Find("floor").GetComponent<Renderer>().bounds.size.z;

        // get position of drone
        float droneX = transform.position.x;
        float droneZ = transform.position.z;

        return droneZ == floorLength / 2 || droneZ == -floorLength / 2 || droneX == -floorWidth / 2 || droneX == floorWidth / 2;
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
        if (Input.GetKey(KeyCode.W))
        {
            wPressed = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            sPressed = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            aPressed = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dPressed = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            upPressed = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            downPressed = true;
        }

        // left and right arrow keys rotate drone
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftPressed = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightPressed = true;
        }

        // if space is pressed then land drone
        if (Input.GetKey(KeyCode.Space))
        {
            if(flying) {

                landDrone();
            }
            else {
                sendCommand("takeoff");
                // print(123);
            }
        }
    }

    private void FixedUpdate() {
        // droneCommand();
        // check if w a s d are pressed and move accordingly
        if (wPressed)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            wPressed = false;
        }
        if (sPressed)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            sPressed = false;
        }
        if (aPressed)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            aPressed = false;
        }
        if (dPressed)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            dPressed = false;
        }
        if (upPressed)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            upPressed = false;
        }
        if (downPressed)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            downPressed = false;
        }

        // left and right arrow keys rotate drone
        if (leftPressed)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
            leftPressed = false;
        }
        if (rightPressed)
        {
            transform.Rotate(Vector3.down * speed * Time.deltaTime);
            rightPressed = false;
        }
    }

    public void sendCommand(string command){
        droneSocket.Send(Encoding.UTF8.GetBytes(command));
        // print the command sent to the drone
        print(command);
    }

    public void landDrone(){
        sendCommand("land");
    }

    public void droneCommand(){
        // if w is pressed then forwardBack is DroneSpeed
        // if s is pressed then forwardBack is -DroneSpeed
        // if neither w or s is pressed then forwardBack is 0
        float forwardBack = 0;
        if (wPressed)
        {
            forwardBack = DroneSpeed;
        }
        else if (sPressed)
        {
            forwardBack = -DroneSpeed;
        }

        // if a is pressed then leftRight is -DroneSpeed
        // if d is pressed then leftRight is DroneSpeed
        // if neither a or d is pressed then leftRight is 0
        float leftRight = 0;
        if (aPressed)
        {
            leftRight = -DroneSpeed;
        }
        else if (dPressed)
        {
            leftRight = DroneSpeed;
        }

        float upDown = 0;
        if (upPressed)
        {
            upDown = DroneSpeed;
        }
        else if (downPressed)
        {
            upDown = -DroneSpeed;
        }

        float leftRightRot = 0;
        if (leftPressed)
        {
            leftRightRot = -DroneSpeed;
        }
        else if (rightPressed)
        {
            leftRightRot = DroneSpeed;
        }
        
        string sendString = $"rc {leftRight} {forwardBack} {upDown} {leftRightRot}";
        print(sendString);
        sendCommand(sendString);
    }
}
