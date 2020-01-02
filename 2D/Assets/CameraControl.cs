using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    [Header("速度"), Range(0, 10)]
    public float speed = 3;
    private Transform target;

    // Use this for initialization
    void Start() {
        target = GameObject.Find("fox").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 cam = transform.position;
        Vector3 tar = target.position;
        tar.z = -10;
        tar.y = Mathf.Clamp(tar.y, -1, 1) ;
       transform.position= Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);
    }
}
