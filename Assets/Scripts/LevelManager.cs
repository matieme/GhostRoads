using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public GameObject level;
    public GameObject _lastlevel;

    public GameObject[] levelContainer;


    void Start () 
    {

        for (int index = 0; index < 20; index++)
        {
            SpawnPlatform();
        }
	}

    void SpawnPlatform()
    {
        int randonNumber = Random.Range(0, levelContainer.Length);

        for (int i = 0; i < levelContainer.Length; i++){
            if (i == randonNumber)
                level = levelContainer[i];
        }

        _lastlevel = Instantiate(level, new Vector3(_lastlevel.transform.position.x, _lastlevel.transform.position.y, _lastlevel.transform.position.z + 241.5f), Quaternion.identity) as GameObject;
    }
}
