using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * _speed;
        transform.Translate(xValue, 0, zValue);
    }
}
