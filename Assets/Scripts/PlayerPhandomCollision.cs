using UnityEngine;
using System.Collections;

public class PlayerPhandomCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            var bc = col.gameObject.GetComponent<BoxCollider>();
            var cc = col.gameObject.GetComponent<CapsuleCollider>();

            if(bc != null)
                bc.isTrigger = true;

            if (cc != null)
                cc.isTrigger = true;
        }
    }
}
