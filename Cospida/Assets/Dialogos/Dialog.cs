using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public Animator textDisplayAnim;

    public GameObject DialogContainer;
    public bool sendScene = false;
    public string scenetoSend = "Nivel1";
    bool first;

    private void Awake()
    {
        textDisplay.text = "";
        first = true;
    }


    void OnEnable()
    {
        if (!first)
        {
            textDisplay.text = "";
            index = 0;
            StartCoroutine(Type());
        }
    }

    private void OnDisable()
    {
        first = false;
        StopAllCoroutines();
        textDisplay.text = "";
        index = 0;

    }

    void Start()
    {
        StartCoroutine(Type());
        
    }
    void Update()
    {

        InputDetect();

    }

    void InputDetect()
    {
        if (textDisplay.text == sentences[index])
        {

            if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z)))
            {
                PreNextSentence();
            }

            if (Input.GetMouseButtonDown(0))
            {
                PreNextSentence();
            }

        }
    }

    void PreNextSentence()
    {
        textDisplayAnim.SetBool("Change", true);
        NextSentence();
    }

    IEnumerator Type()
    {

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    public void NextSentence()
    {
        
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            
            textDisplay.text = "";
            if (sendScene)
            {
                SceneManager.LoadScene(scenetoSend);
            }
            DialogContainer.SetActive(false);
        }
    }
}
