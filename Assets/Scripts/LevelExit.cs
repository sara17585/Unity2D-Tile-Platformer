using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float exitTime = 1f;
    [SerializeField] float slowMoFactor = 0.1f;

    private void OnTriggerEnter2D(Collider2D player)
    {
        GameObject playerCollider = player.gameObject;
        if (playerCollider.GetComponent<Player>())
        {
            StartCoroutine(Exit());
        }
    }


    IEnumerator Exit()
    {
        
        Time.timeScale = slowMoFactor;
        yield return new WaitForSecondsRealtime(exitTime);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
}

