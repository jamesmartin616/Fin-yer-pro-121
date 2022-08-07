using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class loadlevel : MonoBehaviourPunCallbacks
{
    bool player = false;
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
    public static loadlevel instance;
    public IEnumerator LoadingLevel()
    {
        StartUp();
        loadGame = SceneManager.LoadSceneAsync(4);
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
        instance = this;
        StartCoroutine(LoadingLevel());
    }
    private void StartUp()
    {

        
        vignetteEfect = transform.Find("VignetteEfect").GetComponent<Image>();
        vignetteEfect.color = new Color(vignetteEfect.color.r, vignetteEfect.color.g, vignetteEfect.color.b, vignetteEfectVolue);

        if (backGroundImageAndLoop)
            StartCoroutine(transitionImage());
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
}
