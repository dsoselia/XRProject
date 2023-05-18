using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Meta.WitAi.TTS.Utilities;
// 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

public class GPTMan : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject tts;

    public UnityEvent<string> chatGPTRequest = new UnityEvent<string>();
    bool sentRequest = true;
    bool completedRequest = false;


    void Start()
    {
        // chatGPTRequest.Invoke("Explain in three sentences or less how to make the sign in american sign language for the letter a");

    }

    // Update is called once per frame
    void Update()
    {
        if (sentRequest == false)
        {
            chatGPTRequest.Invoke("Explain in three sentences or less how to make the sign in american sign language for the letter a");
            Debug.Log("sent request");
            sentRequest = true;
        }
        else
        {
            // Debug.Log("Already sent request");
        }
        
    }


    public void ProcessGPTResponse(string response)
    {
        if (response != null)
        {
            Debug.Log("Received response");
            Debug.Log(response);

            SaySomething(response);

        }
        else
        {
            Debug.Log("Received null response");
        }
    }

    void SaySomething(string response)
    {
        if (response != null)
        {
            Debug.Log("Saying something");
            TTSSpeaker speaker = tts.gameObject.GetComponent<TTSSpeaker>();
            speaker.Speak(response);
        }
        else
        {
            Debug.Log("Not saying something");
        }

    }
}

