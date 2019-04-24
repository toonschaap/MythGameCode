using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableHitBox : MonoBehaviour
{
    [SerializeField]
    private Collider HitBox;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HitBox.enabled = false;
        }
        else
        {
            HitBox.enabled = true;
        }

    }
}
