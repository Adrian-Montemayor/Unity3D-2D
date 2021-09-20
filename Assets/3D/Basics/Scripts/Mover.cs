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
        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void PrintInstruction()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Don't hit the walls");
    }

    private void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * _speed;
        transform.Translate(xValue, 0, zValue);
    }
}
