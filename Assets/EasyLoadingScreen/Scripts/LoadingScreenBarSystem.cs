using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class LoadingScreenBarSystem : MonoBehaviourPunCallbacks
{
    bool player=false;
    public float speed;
    public Slider bar;
    public Text loadingText;
    public bool backGroundImageAndLoop;
    public float LoopTime;
    public GameObject[] backgroundImages;
    [Range(0, 1f)] public float vignetteEfectVolue; // Must be a value between 0 and 1
    bool async;
    AsyncOperation loadGame;
    Image vignetteEfect;
    IEnumerator LoadLevel()
    {
        loadGame = SceneManager.LoadSceneAsync(1);  
        while (!loadGame.isDone)
        {
            float progress = Mathf.Clamp01(loadGame.progress / 0.9f);
            bar.value = progress;
            loadingText.text = "%" + (100 * bar.value).ToString("####");
            yield return null;
        }
    }

    private void Start()
    {
       
        PhotonNetwork.ConnectUsingSettings();
        vignetteEfect = transform.Find("VignetteEfect").GetComponent<Image>();
        vignetteEfect.color = new Color(vignetteEfect.color.r, vignetteEfect.color.g, vignetteEfect.color.b, vignetteEfectVolue);

        if (backGroundImageAndLoop)
            StartCoroutine(transitionImage());
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnected();
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        async = true;
        bar.value = 0f;
        StartCoroutine(LoadLevel());
    }
    // The pictures change according to the time of
    IEnumerator transitionImage()
    {
        for (int i = 0; i < backgroundImages.Length; i++)
        {
            yield return new WaitForSeconds(LoopTime);
            for (int j = 0; j < backgroundImages.Length; j++)
                backgroundImages[j].SetActive(false);
            backgroundImages[i].SetActive(true);
        }
    }

    // Activate the scene 
    void Update()
    { 
        if (async == false)
        {
            speed = speed + 1f;
            bar.value = speed/500f;
            if (loadingText != null)
                loadingText.text = "%" + (100 *bar.value).ToString("####");
        }
    }

}
