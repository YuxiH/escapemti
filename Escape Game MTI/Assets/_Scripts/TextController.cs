using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    private GameObject player;
    private InputField input;

    void Start()
    {
        player = GameObject.Find("Player");
        input = GetComponent<InputField>();

    }

    private void clearInput()
    {
        input.placeholder.GetComponent<Text>().text = "";
        input.text = "";
    }

    public int inputSize()
    {
        return input.text.Length;
    }

    public void enableInput(string back)
    {
        input.contentType = InputField.ContentType.IntegerNumber;
        input.characterLimit = 3;
        clearInput();
        GetComponent<InputField>().ActivateInputField();
        GetComponent<Image>().enabled = true;
        input.placeholder.GetComponent<Text>().text = back;
    }
    public void enableText(string text)
    {
        input.contentType = InputField.ContentType.Standard;
        input.characterLimit = 0;
        clearInput();
        GetComponent<Image>().enabled = true;
        input.text = text;
        GetComponent<InputField>().DeactivateInputField();
    }

    public void disableInput()
    {
        GetComponent<InputField>().DeactivateInputField();
        clearInput();
        GetComponent<Image>().enabled = false;
    }

}
