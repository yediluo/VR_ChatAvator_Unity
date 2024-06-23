using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

using UnityEngine;
using OpenAI;




public class ChatGPTManager : MonoBehaviour
{
    private OpenAIApi openAI = new OpenAIApi();
    private List<ChatMessage> messages = new List<ChatMessage>();
    public TMP_Text outputText; //
    public bool enableSpeech;




    void Awake()
    {
        // Assuming the OpenAIApi class has a constructor or method that accepts an API key.
        // Please replace "sk-123" with your actual API key.
        openAI = new OpenAIApi("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");
    }

    


    public async void AskChatGPT(string newText)
    {
        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";

        messages.Add(newMessage);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        request.Model = "gpt-3.5-turbo";

        var response = await openAI.CreateChatCompletion(request);
        if (response.Choices != null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            outputText.text = chatResponse.Content;
            Debug.Log(chatResponse.Content);
            if (enableSpeech)
            {
                if (GetComponent<TextToSpeech>().audioSource.isPlaying)
                {
                    GetComponent<TextToSpeech>().audioSource.Stop(); // Stop the currently playing clip
                }

                StartCoroutine(GetComponent<TextToSpeech>().GenerateSpeech(chatResponse.Content));
                //start speech
                //StartCoroutine(tts_object.GenerateSpeech(chatResponse.Content));

            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the combined info from PlayerPrefs
        string user_info = PlayerPrefs.GetString("UserInfo", "DefaultInfo");
        string ai_info = PlayerPrefs.GetString("AI_Info");
        string combinedInfo = user_info + ai_info;
        // Optionally, retrieve other pieces of info if needed
        string userName = PlayerPrefs.GetString("UserName", "DefaultName");
        // ... retrieve other fields as needed ...

        // Use the info as needed, for example, immediately ask ChatGPT
        AskChatGPT(combinedInfo);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}


