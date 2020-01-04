using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
        PhotonNetwork.Instantiate( playerPrefab.name, new Vector3( Random.Range(-5f, 5f), Random.Range(0f, 3f)), Quaternion.identity );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LeaveRoom(  )
    {
        PhotonNetwork.LeaveRoom();
    }
    // Вызывается, когда локальный игрок покинул комнату
    public override void OnLeftRoom()
    {
        Debug.Log("Player left the room");
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
       // Instantiate(playerPrefab, new Vector3(2.0F, 0, 0), Quaternion.identity);
        Debug.Log( newPlayer.NickName + " enter the room" );
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " left the room");
    }
}
