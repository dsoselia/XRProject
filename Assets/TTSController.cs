using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Meta.WitAi.TTS.Utilities;

public class TTSController : MonoBehaviour
{
    public GameObject tts;
    public GameObject avatar;
    int counter = 0;
    int loopCooldown = 0;
    public GameObject handCapture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if space is pressed, say hello world
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (counter == 0){
                Debug.Log("Space pressed");        
                TTSSpeaker speaker = tts.gameObject.GetComponent<TTSSpeaker>();
                speaker.Speak("Hey there I am Roe and today's lesson is all about ASL signs... We'll be going over a number of signs that can be usefuil in your evereday life. So let's get started! I've got you covered.");
                avatar.GetComponent<Animation>().Play("intro");
            }

            else if (counter == 1){
                var text1 = "We'll now start our first lesson, please keep your hands in front of you so I can better assist you. I will be taking you through some common words.";
                TTSSpeaker speaker = tts.gameObject.GetComponent<TTSSpeaker>();
                speaker.Speak(text1);
            }

            else if (counter == 2){
                var text1 = "Monkey";
                TTSSpeaker speaker = tts.gameObject.GetComponent<TTSSpeaker>();
                speaker.Speak(text1);
                avatar.GetComponent<Animation>().Play("00421");
                loopCooldown = 100;
            }

            else if (counter == 3){
                var text1 = "Now it is your turn to try it out. Please try to sign the word monkey.";
                TTSSpeaker speaker = tts.gameObject.GetComponent<TTSSpeaker>();
                speaker.Speak(text1);
            }

            else if (counter == 4){
                if (handCapture.GetComponent<HandCapture>().capturedText == "monkey"){
                    var text1 = "Congratulations, you have successfully signed the word monkey. Now let's move on to the next word.";
                    TTSSpeaker speaker = tts.gameObject.GetComponent<TTSSpeaker>();
                    speaker.Speak(text1);
                }
                else{
                    var text1 = "Sorry, you have not successfully signed the word monkey. Please try again.";
                    TTSSpeaker speaker = tts.gameObject.GetComponent<TTSSpeaker>();
                    speaker.Speak(text1);
                }
                counter = 2;

            }
        

            counter++;
        }
        if (counter == 3 ){
            avatar.GetComponent<Animation>().Play("00421");
            loopCooldown -= 1;
            
        }

        
    }
}
