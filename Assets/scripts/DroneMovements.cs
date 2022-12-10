// class that sends commands to the drone using tcp sockets 
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Socket;


public class DroneMovements{
    private string droneIP = "192.168.10.1";
    private int dronePort = 8889;

    // speeds for drone movements
    private const float speed = 60.0f;

    // booleans to check if w a s d are pressed
    public bool wPressed = false;
    public bool sPressed = false;
    public bool aPressed = false;
    public bool dPressed = false;

    // private Socket droneSocket;

    // constructor
    public DroneMovements(){
        // droneSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM);
        // droneSocket.connect((droneIP, dronePort));
        // droneSocket.send("command".encode());
        // droneSocket.send("takeoff".encode());
    }

    public void landDrone(){
        droneSocket.send("land".encode());
    }

    public void sendCommand(){
        // if w is pressed then forwardBack is speed
        // if s is pressed then forwardBack is -speed
        // if neither w or s is pressed then forwardBack is 0
        float forwardBack = 0;
        if (wPressed)
        {
            forwardBack = speed;
        }
        else if (sPressed)
        {
            forwardBack = -speed;
        }

        // if a is pressed then leftRight is -speed
        // if d is pressed then leftRight is speed
        // if neither a or d is pressed then leftRight is 0
        float leftRight = 0;
        if (aPressed)
        {
            leftRight = -speed;
        }
        else if (dPressed)
        {
            leftRight = speed;
        }
        string sendString = "rc {} {} {} {}".format(leftRight, forwardBack, 0, 0);

        

        // send command to drone using tcp socket
        // sendString = sendString.encode();
        // droneSocket.send(sendString);

    }
}