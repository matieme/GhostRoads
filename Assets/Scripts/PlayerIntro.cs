using UnityEngine;
using System.Collections;

public class PlayerIntro : MonoBehaviour
{
    private Animator _anim;
    public GameObject player;


    void OnEnable()
    {
        EasyTouch.On_SimpleTap += On_SimpleTap;
    }

    void OnDisable()
    {
        UnsubscribeEvent();
    }

    void OnDestroy()
    {
        UnsubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        EasyTouch.On_SimpleTap -= On_SimpleTap;
    }

    void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }

    private void On_SimpleTap(Gesture gesture)
    {
        if (gesture.pickedObject == player)
        {
            int randonNumber = Random.Range(0,2);

            if(randonNumber == 0)
                _anim.SetTrigger("Bite Attack");
            else
                _anim.SetTrigger("Defend");
        }
    }
}
