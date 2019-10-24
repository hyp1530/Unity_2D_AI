using UnityEngine;

public class Fox : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string foxName = "狐狸";
    public bool pass = false;

    private Rigidbody2D r2D;
   // private Transform tra;
    private void Start()
    {
        r2D = GetComponent<Rigidbody2D>();
    //    tra = GetComponent<Transform>();
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.A)) transform.eulerAngles = new Vector3(0, 180, 0);
    }
    private void FixedUpdate()

    {        
        r2D.AddForce(new Vector2(speed*Input.GetAxis("Horizontal"), 0));
    }
}
