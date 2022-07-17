using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDamageNumbers : MonoBehaviour
{
    public void DestroyNumParent()
    {
        Destroy(this.gameObject);//.transform.parent.gameObject);
    }
}