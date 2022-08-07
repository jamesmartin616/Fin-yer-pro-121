
using UnityEngine;
using Photon.Pun;
public class spawn : MonoBehaviour
{
   
    public GameObject spawnPosition;
    public GameObject[] players;
    void Start()
    {
        
            PhotonNetwork.Instantiate(players[Changeplayer.instance.selectedplayer].name, spawnPosition.transform.position, spawnPosition.transform.rotation);
        
    }

    
}
