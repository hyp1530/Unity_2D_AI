using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    #region
    public enum state
    {
        normal, notComplete, complete
    }
    public state _state;

    [Header("對話")]
    public string SayStart = "嗨!你好，幫我找到十個果實。";
    public string SayNotComplete = "你還沒找到十個果實。";
    public string SayComplete = "感謝你幫助我!";
    [Header("對話速度")]
    public float speed = 1.5f;
    public AudioClip soundSay;

    [Header("任務相關")]
     public bool complete;
    public int CountPlayer ;
    public int CountFinish = 10;

    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;

    private AudioSource aud;
 #endregion
    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "fox")
            Say();        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "fox")
            SayClose();
    }
    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (CountPlayer >= CountFinish) _state = state.complete;

        switch (_state)

        {
            case state.normal:
                StartCoroutine(ShowDialog(SayStart));
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(SayNotComplete));
                break;
            case state.complete:
                StartCoroutine(ShowDialog(SayComplete));
                break;
        }
    }
        private IEnumerator ShowDialog(string say)
        {
            textSay.text = "";                              

            for (int i = 0; i < say.Length; i++)      
            {
                textSay.text += say[i].ToString();     
                aud.PlayOneShot(soundSay, 0.6f);
                yield return new WaitForSeconds(speed);    
            }

        }
    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }
    public void PlayerGet()
    {
        CountPlayer++;
    }
}