using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks {

    public Text LogText;
	// Use this for initialization
	void Start () {
        PhotonNetwork.NickName = "Player " + Random.Range(1, 10);
        Log("Connected player name is " + PhotonNetwork.NickName );

        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.ConnectUsingSettings();
	}

    public override void OnConnectedToMaster()
    {
        Log("Connected to master");
    }


    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom( null, new Photon.Realtime.RoomOptions { MaxPlayers = 5 } );
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log( "Joined to the room" );
        PhotonNetwork.LoadLevel( "Game" );
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void Log( string text )
    {
        LogText.text = LogText.text + "\n";
        LogText.text += text;
    }
}
