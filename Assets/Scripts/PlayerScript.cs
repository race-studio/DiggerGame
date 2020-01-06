using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour {

  //  public Camera mainCamera;

    private PhotonView photonView;

    private Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform cirTarg;
    public float radCir = 0.5f;
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
        
        rb.AddForce (transform.up*jumpForce, ForceMode2D.Impulse);   
    }
	// Update is called once per frame
	void Update ()
    {

        // = GameObject.FindGameObjectsWithTag("cheker");

        if (!photonView.IsMine) return;

		if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            transform.Translate( -Time.deltaTime * 5, 0, 0 );
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Time.deltaTime * 5, 0, 0);
        }

        if (Input.GetButtonDown("Jump")){
            Jump();
        }
    }
        
}
