using UnityEngine;
using UnityEngine.Serialization;

public class PowerBarController : MonoBehaviour {

    public PlayerMovement player;
    public float speedUp = 18f;
    public float speedDown = 190f;

    public float statusBar;

    [SerializeField] private RectTransform rectTransform;

    void Start ()
    {
        rectTransform.localPosition = new Vector3(0, -215, 0);
	}

    void Update()
    {
        statusBar = rectTransform.localPosition.y;

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
        }

        if (statusBar < -210f)
        {
            speedDown = 0f;
            speedUp = 18f;
        }

        rectTransform.localPosition = new Vector3(0, statusBar, 0);
    }
}
