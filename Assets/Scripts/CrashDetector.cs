using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _reloadDelay = 1.5f;
    [SerializeField] ParticleSystem _crashEffect;
    [SerializeField] AudioClip _crashSFX;
    bool _hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !_hasCrashed)
        {
            _hasCrashed = true;
            _crashEffect.Play();
            Invoke("ReloadScene", _reloadDelay);
            GetComponent<AudioSource>().PlayOneShot(_crashSFX);
            FindAnyObjectByType<PlayerController>().DisableControls();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
