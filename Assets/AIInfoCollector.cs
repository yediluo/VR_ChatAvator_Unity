using UnityEngine;
using UnityEngine.UI; //
using TMPro;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class AIInforCollector : MonoBehaviour
{
    public ChatGPTManager chatGPTManager;
    public TMP_Dropdown companion_usage;
    public TMP_Dropdown evo_att;
    public TMP_Dropdown avator_char;
    public TMP_Dropdown I_Or_E;
    public TMP_Dropdown Solitude;
    public TMP_Dropdown act_solitdue;
    public TMP_Dropdown act_companion;
    public TMP_Dropdown attract_spot;
    public TMP_Dropdown ai_gender;
    public TMP_Dropdown initative;
    public TMP_Dropdown love_lang;
    public TMP_Dropdown adventure_level;
    public TMP_Dropdown turnoff;
    public TMP_Dropdown char_type;




    public string constrain1;
    public string constrain2;



    public TMP_Text outputText; //

    public void CombineInfoAndDisplay()
    {
        string companion_usage_s = companion_usage.options[companion_usage.value].text;
        string evo_att_s = evo_att.options[evo_att.value].text;
        string avator_char_s = avator_char.options[avator_char.value].text;
        string I_Or_E_s = I_Or_E.options[I_Or_E.value].text;
        string Solitude_s = Solitude.options[Solitude.value].text;
        string act_solitdue_s = act_solitdue.options[act_solitdue.value].text;
        string act_companion_s = act_companion.options[act_companion.value].text;
        string attract_spot_s = attract_spot.options[attract_spot.value].text;
        string ai_gender_s = ai_gender.options[ai_gender.value].text;
        string initative_s = initative.options[initative.value].text;
        string love_lang_s = love_lang.options[love_lang.value].text;
        string adventure_level_s = adventure_level.options[adventure_level.value].text;
        string turnoff_s = turnoff.options[turnoff.value].text;
        string char_type_s = char_type.options[char_type.value].text;

        string companion_usage_q = "What is your main reason to create a virtual companion? ";
        string evo_att_q = "How do you fell if AI is continuously evolving and adapting over your conversation? ";
        string avator_char_q = "What characteristics do you want your virtual companion have? ";
        string I_Or_E_q = "How do you ususally spend your free time? ";
        string Solitude_q = "How do you percieve solitude? ";
        string act_solitdue_q = "What is your go-to solution when being lonely? ";
        string act_companion_q = "What quality attracts you the most in a companioinship? ";
        string attract_spot_q = "What do you want to do with your virtual companion?";
        string ai_gender_q = "What gender do you want your companion to be? ";
        string initative_q = "How would you like your companion to treat you? ";
        string love_lang_q = "What is your love language? ";
        string adventure_level_q = "How adventurous are you? ";
        string turnoff_q = "What kind of quality is a major turn-off for you? ";
        string char_type_q = "What kind of role do you want your virtual companioin to play? ";



        string combinedInfo = constrain1 + constrain2;
        //combinedInfo += $"Name: {name}, Gender: {gender}, Date of Birth: {dob}, Reasons for needing Virtual Companion: {reason}, action toward solitude: {action}";





        combinedInfo = "your role playing name would be: " + "Alice\n"
            + companion_usage_q + companion_usage_s + "\n"
            + evo_att_q + evo_att_s + "\n"
            + avator_char_q + avator_char_s + "\n"
            + I_Or_E_q + I_Or_E_s + "\n"
            + Solitude_q + Solitude_s + "\n"
            + act_solitdue_q + act_solitdue_s + "\n"
            + act_companion_q + act_companion_s + "\n"
            + attract_spot_q + attract_spot_s + "\n"
            + ai_gender_q + ai_gender_s + "\n"
            + initative_q + initative_s + "\n"
            + love_lang_q + love_lang_s + "\n"
            + adventure_level_q + adventure_level_s + "\n"
            + turnoff_q + turnoff_s + "\n"
            + char_type_q + char_type_s + "\n";



        //outputText.text = combinedInfo; // 


        // ... existing code to combine info ...

        //outputText.text = combinedInfo; // Display combined info

        // Save the combined info into PlayerPrefs
        PlayerPrefs.SetString("AI_Info", combinedInfo);

        //// Save any other individual pieces of info you may need
        //PlayerPrefs.SetString("UserName", nameInputField.text);
        //// ... save other fields as needed ...

        // Save PlayerPrefs
        PlayerPrefs.Save();

        // Load the next scene where ChatGPTManager resides
        SceneManager.LoadScene("GPTScene"); // Replace with your actual scene name





    }





    // Start is called before the first frame update
    void Start()
    {
        constrain1 = "Here is the expectation from user towards virtual companion, please stick to those expection and preference.\n";
        constrain2 = "please stick on the role you are playing\n";


    }

    // Update is called once per frame
    void Update()
    {

    }
}