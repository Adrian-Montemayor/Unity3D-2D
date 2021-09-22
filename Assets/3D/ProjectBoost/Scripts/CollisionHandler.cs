using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    Movement movementComponent;
    [SerializeField]
    float levelLoadDelay = 2f;
    [SerializeField]
    AudioClip success;
    [SerializeField]
    AudioClip crash;

    AudioSource audioSource;
    bool isTransitioning = false;

    private void Start()
    {
        movementComponent = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;

            case "Fuel":
                Debug.Log("You picked up fuel");
                Destroy(collision.gameObject);
                break;
            case "Spawn":
                Debug.Log("You are in the initial position");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.PlayOneShot(success);
        movementComponent.enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.PlayOneShot(crash);
        movementComponent.enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
