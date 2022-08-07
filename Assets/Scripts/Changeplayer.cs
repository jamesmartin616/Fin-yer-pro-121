using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Changeplayer : MonoBehaviour
{
    public Button buttonRight;
    public Button buttonLeft;
    public Transform position;
    public GameObject[] players;
    public GameObject[] playersName;
    private int TotalPlayers;
    public int selectedplayer;
    public static Changeplayer instance;
    void Start()
    {
        
        instance = this;
        TotalPlayers = players.Length;
        if (selectedplayer == 0)
        {
            buttonLeft.interactable = false;
            buttonRight.interactable = true;
        }
    }

    public void ChangePlayerLeft()
    {
        if(selectedplayer!=0)
        {
            players[selectedplayer].SetActive(false);
            playersName[selectedplayer].SetActive(false);
            selectedplayer = selectedplayer - 1;
            players[selectedplayer].SetActive(true);
            playersName[selectedplayer].SetActive(true);
        }
        if (selectedplayer == 0)
        {
            buttonLeft.interactable = false;
            buttonRight.interactable = true;
        }
    }
    public void ChangePlayerRight()
    {
        if (selectedplayer != TotalPlayers - 1)
        {
            players[selectedplayer].SetActive(false);
            playersName[selectedplayer].SetActive(false);
            selectedplayer = selectedplayer + 1;
            players[selectedplayer].SetActive(true);
            playersName[selectedplayer].SetActive(true);
        }
        if (selectedplayer == TotalPlayers - 1)
        {
            buttonRight.interactable = false;
            buttonLeft.interactable = true;
        }

    }
}
