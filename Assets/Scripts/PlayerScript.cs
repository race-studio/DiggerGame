using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour {

    //  public Camera mainCamera;
    private Rigidbody2D rb;

    private Vector2 dir;
    public float speed;

    public Transform cirTarg;
    public float jumpForce = 1100f;
    private float radCir = 1f;

    public bool isRight = true;

    // Use this for initialization
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        GameObject[] chekers = GameObject.FindGameObjectsWithTag("cheker");

        foreach (GameObject cheker in chekers) {
            cirTarg = cheker.transform;
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        getInput();
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y); //dir * Time.deltaTime * 60 * 5;
    }

    void getInput()
    {
        dir = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            dir = Vector2.left;
           if (isRight) Flip();
        }

        if (Input.GetKey(KeyCode.D))
        {
            dir = Vector2.right;

            if ( !isRight ) Flip();

        }

        if (Input.GetButtonDown("Jump") && onGround())
        {
            Jump();
        }
    }

    void Flip()
    { 

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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

    // Function jump
    public void Jump()
    {

        rb.AddForce(new Vector2(0f, jumpForce));
    }

}
