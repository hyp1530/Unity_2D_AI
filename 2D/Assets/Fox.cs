using UnityEngine;                  
using UnityEngine.Events;           

public class Fox : MonoBehaviour  
{
    #region 欄位

    [Header("血量"), Range(0, 200)]
    public float hp = 100;
    [Header("速度"), Range(0, 200)]
    public int speed = 50;
    [Header("跳躍"), Range(0, 3000)]
    public float jump = 3f;               
    public string foxName = "fox";         
    public bool pass = false;              
    public bool isGround;

    public UnityEvent onEat;
    public AudioClip soundProp;

    //private Transform tra;
    private Rigidbody2D r2d;
    private AudioSource aud;
    #endregion

    #region 事件
   
    private void Start()
    {
        
        r2d = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
    }

  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn();
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "櫻桃")
        {
            aud.PlayOneShot(soundProp, 1.2f);
            Destroy(collision.gameObject); 
            onEat.Invoke();                 
        }
    }
    #endregion

    #region 方法
    /// <summary>
    /// 走路
    /// </summary>
    private void Walk()
    {
        if (r2d.velocity.magnitude < 10)
            r2d.AddForce(new Vector2(speed * Input.GetAxisRaw("Horizontal"), 0));
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }


    
    /// <summary>
    /// 轉彎
    /// </summary>
    private void Turn(int direction = 0)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }
    #endregion
    public void Damage(float damage)
    {
       hp -= damage;

    }
}