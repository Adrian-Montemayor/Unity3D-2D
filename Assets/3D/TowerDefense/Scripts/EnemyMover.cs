using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    List<WayPoint> path = new List<WayPoint>();
    [SerializeField]
    float waitTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        PrintWayPointName();
        StartCoroutine(MoveRoutine());
    }

    void PrintWayPointName()
    {
        foreach(var point in path)
        {
            Debug.Log(point.name);
        }
    }

    IEnumerator MoveRoutine()
    {
        yield return new WaitForSeconds(waitTime);
        foreach(var point in path)
        {
            transform.position = point.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
