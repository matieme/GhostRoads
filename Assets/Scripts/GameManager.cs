using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public Button restart;
    public PlayerMovement player;
    public const float SPAWN_TIME = 1.0f;
 

	void Update () 
    {
        if (player.isDead)
            StartCoroutine(SpawnRestart(SPAWN_TIME));
	}

    IEnumerator SpawnRestart(float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);
        restart.gameObject.SetActive(true);        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
