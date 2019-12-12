using UnityEngine;
using UnityEngine.Events;

public class Fox : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string foxName = "狐狸";
    public bool pass = false;
    public bool isGround;

    public UnityEvent onEat;

    private Rigidbody2D r2D;
    // private Transform tra;
    private void Start()
    {
        r2D = GetComponent<Rigidbody2D>();
        //    tra = GetComponent<Transform>();

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
        Jump();
    }
    private void FixedUpdate()
    {
        Walk();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        // Debug.Log("碰到東西" + collision.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "櫻桃")
        {
            Destroy(collision.gameObject);  // 刪除
            onEat.Invoke();                 // 呼叫事件
        }
        private void Walk()
        {
            r2D.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
        }
        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
            {
                isGround = false;
                r2D.AddForce(new Vector2(0, jump));
            }

        }
        private void Turn(int direction)
        {
            transform.eulerAngles = new Vector3(0, direction, 0);
        }

    }
}
