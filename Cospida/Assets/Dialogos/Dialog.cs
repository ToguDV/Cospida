using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public Animator textDisplayAnim;

    public GameObject DialogContainer;
    public bool sendScene = false;
    public bool setBoolAnimatorWhenFinish; 
    public bool valueToSetAnimator;
    public bool followCineMachine;
    public GameObject objectToFollow;
    public string boolAnimator;
    public string scenetoSend = "Nivel1";
    bool first;
    public Animator animator;
    public Vector2[] positions;
    public float[] speeds;
    CinemachineVirtualCamera cinemachine;

    private void Awake()
    {
        if (followCineMachine)
        {
            cinemachine = GameObject.Find("CM").GetComponent<CinemachineVirtualCamera>();
            cinemachine.m_Follow = objectToFollow.transform;
        }
        UpdateNPCPosicion();
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
        UpdateNPCPosicion();
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(speeds[index]);
        }

    }

    public void UpdateNPCPosicion()
    {
        animator.SetFloat("x", positions[index].x);
        animator.SetFloat("y", positions[index].y);
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
            if (setBoolAnimatorWhenFinish)
            {
                animator.SetBool(boolAnimator, valueToSetAnimator);
            }

            if (followCineMachine)
            {
                cinemachine.m_Follow = GameObject.Find("Player").transform;
            }

            DialogContainer.SetActive(false);
        }
    }
}
