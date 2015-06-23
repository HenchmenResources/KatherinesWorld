using UnityEngine;
using System.Collections;

public class DraggableObject : MonoBehaviour {

    void OnCollisionStay(Collision hit)
    {
        Collider c = hit.collider;
        if (c.gameObject.tag == "FreezeEffectHorizontal" || c.gameObject.tag == "FreezeEffectVertical" || c.gameObject.tag == "FreezeEffectDiagonalPos" || c.gameObject.tag == "FreezeEffectDiagonalNeg")
            transform.parent = c.transform;
        else
            transform.parent = null;
    }
}
