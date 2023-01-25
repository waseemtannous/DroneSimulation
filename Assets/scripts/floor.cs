using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;


public class floor : MonoBehaviour
{

    public Texture2DArray receivedImage;

    // Start is called before the first frame update
    void Start()
    {
        receivedImage = new Texture2DArray(1920, 1080, 1, TextureFormat.RGBA32, false);
        GetComponent<Renderer>().material.mainTexture = receivedImage;
    }


    // Update is called once per frame
    void Update()
    {
        // create new texture with 2x2 size with random data
        // byte[] data = new byte[1920 * 1080];
        // new System.Random().NextBytes(data);

        Color32[] data = new Color32[1920 * 1080];
        for (int i = 0; i < data.Length; i++)
        {
            // random data
            data[i] = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        }
        // create png from data
        // load data as grayscale image (1 channel)
        
        // load data as grayscale image (1 channel)
        // receivedImage.LoadRawTextureData(data);
        // receivedImage.LoadImage(data);
        receivedImage.SetPixels32(data, 0);

        // apply texture
        GetComponent<Renderer>().material.mainTexture = receivedImage;
    }
}
