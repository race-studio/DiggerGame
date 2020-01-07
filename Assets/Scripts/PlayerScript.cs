using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour {

    //  public Camera mainCamera;

    private PhotonView photonView;
    private Rigidbody2D rb;

    [SerializeField]
    private Vector2 dir;
    public float speed;

    public Transform cirTarg;
    public float jumpForce = 20f;
    public float radCir = 0.5f;

    public bool isRight = true;

    // Use this for initialization
    void Start () {
        photonView = GetComponent<PhotonView>();
        
        rb = GetComponent<Rigidbody2D> ();
    }

    bool onGround(){
        Collider2D[] og = Physics2D.OverlapCircleAll(cirTarg.position, radCir);
        int j =0;
        for(int i = 0; i < og.Length; i++){
            if (og[i].gameObject != gameObject)
                j++;
        }
        return j > 0;
    } 
    
    // Function jump
    public void Jump (){
        
        rb.AddForce(new Vector2(0f, jumpForce));   
    }

	// Update is called once per frame
	void Update ()
    {
        Debug.Log( "Before " + rb.velocity);
        // = GameObject.FindGameObjectsWithTag("cheker")
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        getInput();
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y); //dir * Time.deltaTime * 60 * 5;

        Debug.Log("After " + rb.velocity);


    }

    void getInput()
    {
        //Для тестов персонажа закомментировать эту строчку, создать плеера на сцене и закинуть его трансформ в слот на MainCamer

        if (!photonView.IsMine) return;
        dir = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
            if (isRight) Flip();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;

            if ( !isRight ) Flip();

        }
    }

    void Flip()
    {
        isRight = !isRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
