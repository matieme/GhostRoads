using UnityEngine;
using System.Collections;

public class PowerBarController : MonoBehaviour {

    public PlayerMovement player;
    public float speedUp = 18f;
    public float speedDown = 190f;

    float statusBar;

    public RectTransform RectTransform;

    void Start ()
    {
        RectTransform = GetComponent<RectTransform>();
        RectTransform.localPosition = new Vector3(0, -215, 0);
	}

    void Update()
    {

        statusBar = RectTransform.localPosition.y;


        if(player.isStarted)
        {
            if (player.isIntoucheable)
                statusBar -= speedDown * Time.deltaTime;
            else
                statusBar += speedUp * Time.deltaTime;
        }


        if (statusBar >= 0)
        {
            speedDown = 190f;
            speedUp = 0f;
            player.canSwipe = true;
            Debug.Log("BAJA");
        }

        if (statusBar <= -214f)
        {
            speedDown = 0f;
            speedUp = 18f;
            Debug.Log("SUBE");
        }

        Debug.Log("UP:  " + speedUp);
        Debug.Log("DOWN:  " + speedDown);
        RectTransform.localPosition = new Vector3(0, statusBar, 0);
    }
}
