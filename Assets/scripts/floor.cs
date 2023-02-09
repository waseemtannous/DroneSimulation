using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

// using OpenCvSharp;
// using OpenCvSharp.Unity;

// using UnityEngine.Video;



public class floor : MonoBehaviour
{
    // string udpUrl = "udp://192.168.10.2:11111";
    // private OpenCvSharp.VideoCapture capture;
    // private Texture2D texture;


    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate() {
        string path = "/Users/waseem/Desktop/githubRepos/PythonRandom/frame.jpg";
        byte[] bytes = File.ReadAllBytes(path);
        Texture2D receivedImage = new Texture2D(1, 1, TextureFormat.RGBA32, false);
        // receivedImage.LoadRawTextureData(bytes);
        receivedImage.LoadImage(bytes);
        receivedImage.Apply();
        GetComponent<Renderer>().material.mainTexture = receivedImage;
        print(receivedImage.width + " " + receivedImage.height);
    }
}