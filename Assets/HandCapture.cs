using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class HandCapture : MonoBehaviour
{
    public RenderTexture handCaptureTexture;
    public string savePath = "Assets/CapturedImages/";
    public int frameRate = 1;
    private int _frameCounter = 0;
    private float _timeCounter = 0f;
    public string capturedText = "";
    
    // create string current recognitions

    public string currentRecognitions = "";
    //public string target
    public string target = "";

    void Start()
    {
        
    }
    
    int checkPrediction(string prediction)
    {
        if (prediction == target)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    void Update()
    {
        _timeCounter += Time.deltaTime;

        if (_timeCounter >= 1f / frameRate)
        {
            _timeCounter = 0f;
            StartCoroutine(CaptureHand());
        }
    }
    IEnumerator CaptureHand()
    {
        RenderTexture.active = handCaptureTexture;
        Texture2D texture2D = new Texture2D(handCaptureTexture.width, handCaptureTexture.height, TextureFormat.RGB24, false);
        texture2D.ReadPixels(new Rect(0, 0, handCaptureTexture.width, handCaptureTexture.height), 0, 0);
        texture2D.Apply();

        byte[] bytes = texture2D.EncodeToJPG();
        string filePath = savePath + "HandCapture_" + _frameCounter.ToString("0000") + ".jpg";
        // File.WriteAllBytes(filePath, bytes); 

        // To feed the texture data to your machine learning model, you can use the "bytes" variable here
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormFileSection("file", bytes, filePath, "image/jpeg"));

        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/files", formData))
        {
            www.SetRequestHeader("accept", "application/json");
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                capturedText+= www.downloadHandler.text;
            }
            else
            {
                Debug.Log("Error uploading image: " + www.error);

            }
        }

        RenderTexture.active = null;
        Destroy(texture2D);

        _frameCounter++;
    }
}
