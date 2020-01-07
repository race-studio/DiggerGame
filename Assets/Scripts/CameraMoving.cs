using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject targetPlayer;
    private PhotonView playerPhotonView;

    // Start is called before the first frame update
    void Start()
    {
        //if (!PhotonView.IsMine) return;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPlayer)
        {
           // float y = (float)Math.Round(targetPlayer.transform.position.y, 1);
            transform.position = new Vector3(targetPlayer.transform.position.x + 4f, targetPlayer.transform.position.y + 2f, transform.position.z);
        }
        else
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject player in players)
            {
                playerPhotonView = player.GetComponent<PhotonView>();

                if (playerPhotonView.IsMine)
                {
                    targetPlayer = player;
                    break;
                }
            }
        }
           
    }

}

