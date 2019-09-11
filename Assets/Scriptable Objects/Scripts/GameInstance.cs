using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ELevelType { LEVEL, MENU }

[CreateAssetMenu(fileName = "GameInstance", menuName = "Elias/Game Instance", order = 1)]
public class GameInstance:ScriptableObject
{
    public static GameInstance Instance;
    public string levelToLoad;

    private void OnEnable()
    {
        Instance = this;
    }

    public void ChangeScene(ELevelType _levelType)
    {
        if (_levelType == ELevelType.MENU)
        {            
            GameManager.Instance.LoadNextLevel(levelToLoad);
        }

        if (_levelType == ELevelType.LEVEL)
        {
            Debug.Log("Trying to load level: " + levelToLoad);
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public IEnumerator LoadSceneAsync()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToLoad);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}



