using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

using OpenCvSharp;
using OpenCvSharp.Unity;

using UnityEngine.Video;



public class floor : MonoBehaviour
{
    string udpUrl = "udp://192.168.10.2:11111";
    private OpenCvSharp.VideoCapture capture;
    private Texture2D texture;


    // Start is called before the first frame update
    void Start()
    {
        capture = new OpenCvSharp.VideoCapture(udpUrl);
        texture = new Texture2D(1, 1, TextureFormat.RGBA32, false);
        GetComponent<Renderer>().material.mainTexture = texture;
    }


    // Update is called once per frame
    void Update()
    {
        Mat frame = new Mat();
        if (capture.Read(frame) && !frame.Empty())
        {
            byte[] jpegData = Cv2.ImEncode(".jpg", frame);
            texture.LoadImage(jpegData);
        }
    }
}

