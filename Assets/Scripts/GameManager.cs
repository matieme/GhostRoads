using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public Button restart;
    public PlayerMovement player;
 
	void Start () 
    {
	    
	}

	void Update () 
    {
        if (player.isDead)
            StartCoroutine(SpawnRestart());
	}

    IEnumerator SpawnRestart()
    {
        yield return new WaitForSeconds(1.0f);
        restart.gameObject.SetActive(true);        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
