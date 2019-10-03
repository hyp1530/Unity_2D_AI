using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
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
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
