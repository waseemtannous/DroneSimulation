// this file is for connecting to dji tello drone and get the video stream from it to display in unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;

using System.Text;

using System;

using System.Diagnostics;

using System.Threading;

public class client : MonoBehaviour
{
    // define the socket
    Socket socket;

    // define the ip address of the drone
    string ip = "";

    // define the port number of the drone
    int port = 8889;

    // define the video port number of the drone
    int videoPort = 11111;

    // function to connect to the drone and get the video stream
    public void connect()
    {
        // create a new socket
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        // create a new ip endpoint
        System.Net.IPEndPoint ipEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), port);

        // create a new ip endpoint for video
        System.Net.IPEndPoint videoIpEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), videoPort);

        // create a new udp client
        UdpClient udpClient = new UdpClient();

        // connect to the drone
        udpClient.Connect(ipEndPoint);

        // send the command to the drone
        udpClient.Send(Encoding.UTF8.GetBytes("command"), Encoding.UTF8.GetBytes("command").Length);

        // send the command to the drone
        udpClient.Send(Encoding.UTF8.GetBytes("streamon"), Encoding.UTF8.GetBytes("streamon").Length);

        // create a new thread to get the video stream
        Thread thread = new Thread(() => getVideoStream(videoIpEndPoint));

        // start the thread
        thread.Start();
    }

    // function to get the video stream
    public void getVideoStream(System.Net.IPEndPoint videoIpEndPoint)
    {
        // create a new udp client
        UdpClient udpClient = new UdpClient();

        // connect to the drone
        udpClient.Connect(videoIpEndPoint);

        // create a new byte array to store the video stream
        byte[] videoStream = new byte[1024];

        // display the video stream
        while (true)
        {
            // get the video stream
            videoStream = udpClient.Receive(ref videoIpEndPoint);

            // display the video stream to the screen
            // Debug.Log(videoStream);
        }
    }
}

