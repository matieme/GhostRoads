using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {


    enum PLAYER_STATE
    {
        LEFT,
        RIGHT
    }

    PLAYER_STATE _playerState = PLAYER_STATE.RIGHT;

    public bool isStarted = false;
    public float _speed = 15;

    public bool isLeft;
    public bool isRight;

    private Animator _anim;

    public bool isDead;
    public bool isPhandom;
    public bool canTap;

    public bool canSwipe;
    public bool isIntoucheable;
    public GameObject trigger;

    public Text score;
    private int countPoints;

    private float velocityAmount;

    public Material red;
    public Material blue;

    private SkinnedMeshRenderer _mesh;

    void OnEnable()
    {
        EasyTouch.On_SwipeEnd += On_SwipeEnd;
    }

    void OnDestroy()
    {
        EasyTouch.On_SwipeEnd -= On_SwipeEnd;
    }

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _mesh = GetComponentInChildren<SkinnedMeshRenderer>();

        canTap = true;

        trigger.SetActive(false);
    }


    void Update () 
    {
        if(canTap)
            OnTap();

        var floatCountPoints = transform.position.z + 32;
        countPoints = (int) floatCountPoints;

        SetCountText();

        if(isStarted && !isDead)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
            velocityAmount += 0.0001f * Time.deltaTime;
            _speed += velocityAmount;
        }
    }

    void OnTap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isStarted)
            {
                isStarted = true;
                transform.Rotate(0, 45, 0);
                _anim.SetTrigger("Fly Forward");
            }

            switch (_playerState)
            {
                case PLAYER_STATE.LEFT:
                    _playerState = PLAYER_STATE.RIGHT;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
                    break;
                case PLAYER_STATE.RIGHT:
                    _playerState = PLAYER_STATE.LEFT;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 315, 0));
                    break;
            }
        }
    }

    void On_SwipeEnd(Gesture gesture)
    {
        if (gesture.swipe == EasyTouch.SwipeDirection.Up && gesture.swipeLength > 2f && canTap && canSwipe)
        {
            isPhandom = true;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.layer == 8 && !isIntoucheable)
        {
            _speed = 0;
            _anim.SetTrigger("Die");
            isDead = true;
        }
    }

    void FixedUpdate()
    {
        if (isPhandom)
        {
            trigger.SetActive(true);
            isIntoucheable = true;
            isPhandom = false;
            canTap = false;

            _mesh.material = blue;

            if (_playerState==PLAYER_STATE.LEFT)
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            else if(_playerState == PLAYER_STATE.RIGHT)
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            StartCoroutine(PhandomPower());
        }
    }

    IEnumerator PhandomPower()
    {
        yield return new WaitForSeconds(1.0f);
        
        if (_playerState == PLAYER_STATE.LEFT)
            transform.rotation = Quaternion.Euler(new Vector3(0, 315, 0));
        else if (_playerState == PLAYER_STATE.RIGHT)
            transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));

        yield return new WaitForSeconds(0.1f);

        _mesh.material = red;

        canTap = true;
        isIntoucheable = false;
        canSwipe = false;
        trigger.SetActive(false);
    }

    void SetCountText()
    {
        score.text = "Score: " + countPoints.ToString();
    }
}
