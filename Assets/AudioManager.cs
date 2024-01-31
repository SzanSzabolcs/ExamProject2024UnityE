using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip hurt;
    public AudioClip score;
    public AudioClip fly;
    public AudioClip gameover;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {  
        SFXSource.PlayOneShot(clip); 
    }


}
