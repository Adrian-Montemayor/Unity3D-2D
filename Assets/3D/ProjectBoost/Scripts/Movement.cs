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
    [SerializeField] ParticleSystem thrustParticle;

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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ThrustProcess();

        }
        else if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            StopThrusting();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        thrustParticle.Stop();
    }

    void ThrustProcess()
    {
        rb.AddRelativeForce(Vector3.up * _speed * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!thrustParticle.isPlaying)
        {
            thrustParticle.Play();
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
