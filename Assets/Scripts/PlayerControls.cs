using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private PhotonView photonView;

	// Use this for initialization
	void Start () {
        photonView = GetComponent<PhotonView>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!photonView.IsMine) return;

		if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            transform.Translate( -Time.deltaTime * 5, 0, 0 );
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Time.deltaTime * 5, 0, 0);
        }
    }
}
