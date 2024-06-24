using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.IO;

public class TextToSpeech : MonoBehaviour
{
    private string apiKey = "";
    private string baseUrl = "https://api.openai.com/v1/audio/speech";
    private string model = "tts-1-hd";
    private string voice = "alloy";
    private string inputText = "Hello World, This is a test to see the TTS of OpenAI!";
    private string audioFileName = "speech";
    private string folderPath = "/Users/yediluo/Desktop/Workspace/Unity_Playground/VRAvator/Assets/Resources/";
    public AudioSource audioSource; // Assign this in the inspector

    private void Awake()
    {
 
    }

    private void Start()
    {

       // StartCoroutine(GenerateSpeech(inputText));
    }

    private void Update()
    {
       
    }

    public void startSpeech()
    {

    }


    public IEnumerator GenerateSpeech(string txt)
    {

        SpeechRequest payload = new SpeechRequest
        {
            model = "tts-1-hd",
            voice = "alloy",
            input = txt,
        };

        // Convert the payload to a JSON string.
        string jsonPayload = JsonUtility.ToJson(payload);
        Debug.Log("" + jsonPayload);

        using (UnityWebRequest www = new UnityWebRequest(baseUrl, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonPayload));
            www.downloadHandler = new DownloadHandlerAudioClip(www.url, AudioType.MPEG);
            www.SetRequestHeader("Authorization", "Bearer " + apiKey);
            www.SetRequestHeader("Content-Type", "application/json");


            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {

                Debug.Log(www.GetResponseHeader("Content-Type"));


                string filePath = Path.Combine(folderPath, audioFileName);

                // Saving the audio data as an MP3 file.
                //File.WriteAllBytes(filePath, www.downloadHandler.data);

                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                if (clip != null)
                {
                    audioSource.clip = clip;
                    audioSource.Play();
                    Debug.Log("Audio clip loaded and playing!");

                }
                else
                {
                    Debug.LogError("Failed to load audio clip from memory.");
                }
            }
            else
            {
                Debug.LogError("Failed to generate speech: " + www.error);
            }
        }
    }
    
}
