using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class bot : MonoBehaviour
{
    public GameObject weapon;
    private Rigidbody2D rb;

    private Vector2 dir;
    public float speed;

    public Transform cirTarg;
    public float jumpForce = 20f;
    public GameObject Player;
    public bool isRight = true;
    private float radCir = 1f;
    private float fireRate = 0.2f;
    private float nextFire;
    private float curTime;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
            void Flip()
        {
            isRight = !isRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

       
        if (Player.transform.position.x<transform.position.x){
            Flip();
            dir = Vector2.left;
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
            if (onGround()){
                jump();
            }
        }

        if (Player.transform.position.x>transform.position.x){
            Flip();
            dir = Vector2.right;
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
            if (onGround()){
                jump();
            }
        }
        
    }
     void jump(){
            rb.AddForce(new Vector2(0f, jumpForce));
        }


    bool onGround()
    {
        Collider2D[] og = Physics2D.OverlapCircleAll(cirTarg.position, radCir);
        int j = 0;
        for (int i = 0; i < og.Length; i++)
        {
            if (og[i].gameObject != gameObject)
                j++;
        }
        return j > 0;
    }
    
}
