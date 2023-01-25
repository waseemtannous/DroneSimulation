
// using UnityEngine;
// using System.Net.Sockets;
// using System.Text;
// using System.Collections;
// using System.Net;


// public class Video : MonoBehaviour
// {
//     private static int dronePort = 11111; // specify the port that the camera is sending the video feed on
//     private static string droneIP = "192.168.10.1"; // specify the IP address of the camera

//     Socket droneSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

//     IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, dronePort);


//     // assets -> material -> videoMaterial
//     public Material videoMaterial = new Material(Shader.Find("Unlit/video"));
//     private Texture2D videoTexture;

//     void Start()
//     {
//         droneSocket.Connect(droneIP, dronePort);

//         videoTexture = new Texture2D(1920, 1080);
//         videoMaterial.mainTexture = videoTexture;
//     }

//     void Update()
//     {
//         print(droneSocket.Available);
//         if (droneSocket.Available > 0)
//         {
//             // receive the video feed
//             byte[] data = new byte[droneSocket.Available];
//             droneSocket.Receive(data);
//             print(data.Length);

//             // display the video feed on the canvas
//             videoTexture.LoadImage(data);
//             videoMaterial.mainTexture = videoTexture;

//             // apply the videoMaterial to the canvas
//             videoMaterial.mainTexture = videoTexture;

//         }
//     }
// }



// using UnityEngine;
// using System.Net.Sockets;
// using System.Text;
// using System.Collections;
// using System.Net;
// using UnityEngine.Video;


// public class Video : MonoBehaviour
// {
//     private UdpClient client;
//     private static int port = 11111; // specify the port that the camera is sending the video feed on
//     private static string ip = "192.168.10.1"; // specify the IP address of the camera


//     void Start()
//     {
//         client = new UdpClient(port);
//         // client.Connect(ip, port);

//         // // get the VideoPlayer component named "VideoPlayer" and assign the video feed to it
//         // VideoPlayer videoPlayer = GameObject.Find("VideoPlayer").GetComponent<VideoPlayer>();
//         // // assign the video feed from the udp client to the video player
//         // videoPlayer.clip = VideoClip.Create("video", 1920, 1080, 30, false);
//         // IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, port);
//         // videoPlayer.clip.SetData(client.Receive(ref remoteIpEndPoint), 0);
//         // // play the video
//         // videoPlayer.Play();
//     }

//     void Update()
//     {
//         print(client.Available);
//         if (client.Available > 0)
//         {
//             IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, port);
//             // display the video feed on the VideoPlayer object 
//             byte[] data = client.Receive(ref remoteIpEndPoint);

// // get the video player component named "VideoPlayer" and assign the video feed to it
//             VideoPlayer videoPlayer = GameObject.Find("VideoPlayer").GetComponent<VideoPlayer>();

//             // assign the received frame to the video player
//             // videoPlayer.clip = VideoClip.Create("video", 1920, 1080, 30, false);
//             videoPlayer.clip.SetData(data, 0);

//             // play the video
//             videoPlayer.Play();

//             print("received video feed");

            
//         }
//     }
// }



// using UnityEngine;
// using System.Net.Sockets;
// using System.Text;
// using System.Collections;
// using System.Net;
// using UnityEngine.Video;


// public class Video : MonoBehaviour
// {
//     VideoPlayer videoPlayer;

//     public void Start()
//     {
//         videoPlayer = GetComponent<VideoPlayer>();
//         videoPlayer.url = "udp://0.0.0.0:11111";
//         videoPlayer.Play();

//     }

//     public void Update()
//     {
//         print(videoPlayer.isPlaying);
//     }
// }

