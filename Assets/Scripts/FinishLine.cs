using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _reloadDelay = 3f;
    [SerializeField] ParticleSystem _finishEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _finishEffect.Play();
            
            Invoke("ReloadScene", _reloadDelay);
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }  
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
