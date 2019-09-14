using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager:Singleton<GameManager>
{
    public PlayerController player;
    public Animator transitionAnim;
    public GameObject pressStart;
    public Image anim;

    private void OnEnable()
    {
        PlayerController.OnPlaying += PlayerControl_OnPlaying;
    }

    private void OnDisable()
    {
        PlayerController.OnPlaying -= PlayerControl_OnPlaying;
    }

    private void PlayerControl_OnPlaying(PlayerController _player)
    {
        player = _player;
    }

    public IEnumerator LoadSceneAsync(string _levelToLoad)
    {
        //anim.enabled = true;
        //print("start load async routine");
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_levelToLoad);
        asyncLoad.allowSceneActivation = false;
        //transitionAnim.SetTrigger("FadeToLoad");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            //pressStart.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }

    }

    public void LoadNextLevel(string _levelToLoad)
    {
        StartCoroutine(LoadSceneAsync(_levelToLoad));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //GameInstance.Instance.ChangeScene();
        }

        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
    }
}
