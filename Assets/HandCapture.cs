using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HandCapture : MonoBehaviour
{
    public RenderTexture handCaptureTexture;
    public string savePath = "Assets/CapturedImages/";
    public int frameRate = 10;
    private int _frameCounter = 0;
    private float _timeCounter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        _timeCounter += Time.deltaTime;

        if (_timeCounter >= 1f / frameRate)
        {
            _timeCounter = 0f;
            CaptureHand();
        }
    }

    void CaptureHand()
    {
        RenderTexture.active = handCaptureTexture;
        Texture2D texture2D = new Texture2D(handCaptureTexture.width, handCaptureTexture.height, TextureFormat.RGB24, false);
        texture2D.ReadPixels(new Rect(0, 0, handCaptureTexture.width, handCaptureTexture.height), 0, 0);
        texture2D.Apply();

        byte[] bytes = texture2D.EncodeToPNG();
        string filePath = savePath + "HandCapture_" + _frameCounter.ToString("0000") + ".png";
        File.WriteAllBytes(filePath, bytes);

        // To feed the texture data to your machine learning model, you can use the "bytes" variable here

        RenderTexture.active = null;
        Destroy(texture2D);

        _frameCounter++;
    }
}
