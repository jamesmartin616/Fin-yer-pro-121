using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class Buttons : MonoBehaviourPunCallbacks
{
    int numberRoom = 0;
    bool roomsearch;
    // Start is called before the first frame update
    public void Play()
    {
        
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = 10;
            PhotonNetwork.JoinOrCreateRoom("Game"+numberRoom, roomOptions, TypedLobby.Default);     
        
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        numberRoom = +1;
        Play();
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
