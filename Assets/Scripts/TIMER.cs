using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class TIMER : MonoBehaviour
{
    bool gamestart = false;
    public int timeInInt;
    public Text timerBox;
    bool startTimer = false;
    double startTime=10;
    ExitGames.Client.Photon.Hashtable CustomeValue;

    void Start()
    {
        gamestart = false;
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {

            CustomeValue = new ExitGames.Client.Photon.Hashtable();
            //startTime = PhotonNetwork.Time;
            startTimer = true;
            CustomeValue.Add("StartTime", startTime);
            PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
        }
        else
        {
            
            startTime=(int)PhotonNetwork.CurrentRoom.CustomProperties[CustomeValue];
        }
        
    }

    void Update()
    {
        if (gamestart == false)
        {
            if (!startTimer) return;

            startTime -= Time.deltaTime;
            timeInInt = (int)startTime;
            timerBox.text = timeInInt.ToString() + "s";
            if (startTime <= 0)
            {
                gamestart = true;
                PhotonNetwork.LoadLevel("loadinglevel");
            }
        }
        
    }

}
