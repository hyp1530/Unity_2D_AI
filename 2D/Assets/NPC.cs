using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {
    #region
    public enum state
    {
        normal,notComplete,complete
    }
    public state _state;

    [Header("對話")]
    public string SayStart = "嗨!你好，幫我找到十個果實。";
    public string SayNotComplete = "你還沒找到十個果實。";
    public string SayComplete = "感謝你幫助我!";
    [Header("對話速度")]
    public float speed = 1.5f;
    [Header("任務相關")]
    public bool mission = false;
    public int CountPlayer = 0;
    public int CountFinish = 10;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    #endregion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "fox")
        {
            Say();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "fox")
        {
            SayClose();
            
        }

    }
    private void Say()
    {
        objCanvas.SetActive(true);
        switch (_state)
        {
            case state.normal:
                textSay.text = SayStart;
                break;
            case state.notComplete:
                textSay.text = SayNotComplete;
                break;
            case state.complete:
                textSay.text = SayComplete;
                break;       
        }

    }
    private void SayClose()
    {

        objCanvas.SetActive(false);
    }
}
