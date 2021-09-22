using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float _speed = 1000f;
    [SerializeField]
    private float rotationThrust = 100f;
    AudioSource audioSource;
    [SerializeField]
    AudioClip mainEngine;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        ProccesThrust();
        ProcessRotation();
    }

    private void ProccesThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * _speed * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.Stop();
        }
    }
    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationThrust);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationThrust);
        }

        void ApplyRotation(float rotationThisFrame)
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
            rb.freezeRotation = false;
        }
    }
}
