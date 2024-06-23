using UnityEngine;
using UnityEngine.UI; //
using TMPro;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class UserInfoCollector : MonoBehaviour
{
    public ChatGPTManager chatGPTManager;
    public TMP_InputField nameInputField;
    public TMP_InputField ageInputField;
    public TMP_Dropdown genderInputField;
    public TMP_InputField dobInputField;
    public TMP_Dropdown reasonDropDown;
    public TMP_Dropdown actionDropDown;
    public string constrain1;
    public string constrain2;



    public TMP_Text outputText; //

    public void CombineInfoAndDisplay()
    {
        string name = nameInputField.text;
        string age = ageInputField.text;
        string gender = genderInputField.itemText.text;
        string dob = dobInputField.text;
        string reason = reasonDropDown.options[reasonDropDown.value].text;
        string action = actionDropDown.options[actionDropDown.value].text;

        string combinedInfo = constrain1 + constrain2;
        combinedInfo += $"Name: {name}, Gender: {gender}, Date of Birth: {dob}, Reasons for needing Virtual Companion: {reason}, action toward solitude: {action}";

        //outputText.text = combinedInfo; // 

        // Save the combined info into PlayerPrefs
        PlayerPrefs.SetString("UserInfo", combinedInfo);

        // Save any other individual pieces of info you may need
        PlayerPrefs.SetString("UserName", nameInputField.text);
        // ... save other fields as needed ...

        // Save PlayerPrefs
        PlayerPrefs.Save();

        // Load the next scene where ChatGPTManager resides
        SceneManager.LoadScene("AI Info Prompt"); // Replace with your actual scene name





    }





    // Start is called before the first frame update
    void Start()
    {
        constrain1 = "From now on, You will play the role of a virtual companion machine and here is the userinfo.\n";
        constrain2 = "If you dont get the wake up word \"stop pretend\", please stick to your role.\n";


    }

    // Update is called once per frame
    void Update()
    {

    }
}