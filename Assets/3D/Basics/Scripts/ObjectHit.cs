using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        print("Bumped into a wall");
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnCollisionExit(Collision collision)
    {
        print("Exit from wall's collider");
    }
}
