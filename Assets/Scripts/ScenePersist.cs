using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public class ScenePersist : MonoBehaviour
//{
//    int startingScene;

//    private void Awake()
//    {
//        int numScenePersist = FindObjectsOfType<GameSession>().Length;
//        if (numScenePersist > 1)
//        {
//            Destroy(gameObject);

//        }
//        else
//        {
//            DontDestroyOnLoad(gameObject);
//        }

//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        startingScene = SceneManager.GetActiveScene().buildIndex;
//    }

//    // Update is called once per frame
//    void Update()
//    {

        
//        var currentindex = SceneManager.GetActiveScene().buildIndex;
        

//        if (currentindex != startingScene)
//        {
//            Destroy(gameObject);
//        }
//    }
//}

public class ScenePersist : MonoBehaviour
{
    static ScenePersist instance = null;
    int startingSceneIndex;

    void Start()
    {
        if (!instance)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (startingSceneIndex != SceneManager.GetActiveScene().buildIndex)
        {
            instance = null;
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }
    }
}