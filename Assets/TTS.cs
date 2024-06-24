using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.IO;
using System;




[System.Serializable]
public class SpeechRequest
{
    public string model;
    public string voice;
    public string input;
    public string format;
}

public class TTS : MonoBehaviour
{
    private string apiKey = "";

    private string baseUrl = "https://api.openai.com/v1/audio/speech";
    private string model = "tts-1-hd";
    private string voice = "alloy";
    private string inputText = "Hello World, Our Test For TTS";
    private string audioFileName = "speech.wav";
    private string folderPath = "/Users/yediluo/Desktop/Workspace/Unity_Playground/VRAvator/Assets/Resources";

    private string speechPath = "/Users/yediluo/Desktop/Workspace/Unity_Playground/VRAvator/Assets/Resources/speech.wav";

    private AudioSource audioSource;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        StartCoroutine(GenerateSpeech());
        //StartCoroutine(LoadAudioAndPlay(speechPath));

        // Load the AudioClip named "speech.wav" from the Resources folder
        playAudio();

    }

    public void playAudio()
    {

        
        AudioClip clip = Resources.Load<AudioClip>("speech");

        

        // Check if the AudioClip was loaded successfully
        if (clip != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.playOnAwake = false;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Failed to load the audio clip.");
        }



    }


    


    private IEnumerator GenerateSpeech()
    {

        SpeechRequest payload = new SpeechRequest
        {
            model = model,
            voice = voice,
            input = inputText,
            format = "WAV"
        };

        // Convert the payload to a JSON string.
        string jsonPayload = JsonUtility.ToJson(payload);
        Debug.Log("" + jsonPayload);
        using (UnityWebRequest www = new UnityWebRequest(baseUrl, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonPayload));
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Authorization", "Bearer " + apiKey);
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();



            if (www.result == UnityWebRequest.Result.Success) { 


                // Optionally, check if the folder exists to ensure the directory is valid
                if (!Directory.Exists(folderPath))
                {
                    Debug.LogError("Folder does not exist: " + folderPath);
                    yield break; // Stop execution of this coroutine
                }


                
                // Define the full path for the new audio file within the specified folder
                string filePath = Path.Combine(folderPath, audioFileName);

                // Saving the audio data as an MP3 file at the specified location
                File.WriteAllBytes(filePath, www.downloadHandler.data);
                Debug.Log("Audio file saved as: " + filePath);



            }

            else
            {
                Debug.LogError("Failed to generate speech: " + www.error);
            }

            Debug.Log("enter GenerateSpeech");

        }
    }
}
