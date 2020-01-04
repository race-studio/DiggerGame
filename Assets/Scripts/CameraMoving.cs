using System.Collections;
using System.Collections.Generic;
//using Photon.Pun;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    //private Transform playerTransform;
    //private PhotonView playerPhotonView;

    // Start is called before the first frame update
    void Start()
    {
        //if (!PhotonView.IsMine) return;
    }

    // Update is called once per frame
    void Update()
    {
       /* if ( playerTransform )
        {
            transform.position = new Vector3(playerTransform.position.x + 4f, playerTransform.position.y + 2f, transform.position.z);
        }
        else
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject player in players)
            {
                playerPhotonView = player.GetComponent<PhotonView>();

                if (playerPhotonView.IsMine)
                {
                    playerTransform = player.transform;
                }
            }
        }*/
           
    }

}

