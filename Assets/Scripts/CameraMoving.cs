using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject targetPlayer;
    private PhotonView playerPhotonView;

    private float damping = 2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPlayer)
        {
             float xOffset = 4f;

            if (!targetPlayer.GetComponent<PlayerScript>().isRight) xOffset = -3f;

             float interpolation = damping * Time.deltaTime;

             Vector3 position = transform.position;
             position.y = Mathf.Lerp(transform.position.y, targetPlayer.transform.position.y + 1f, interpolation);
             position.x = Mathf.Lerp(transform.position.x, targetPlayer.transform.position.x + xOffset, interpolation);

             transform.position = position;

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

