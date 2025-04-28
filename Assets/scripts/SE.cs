using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayClicksound()
    {
        if(audioSource != null && clickSound !=null)
        {
            audioSource.PlayOneShot(clickSound); ;
        }
    }
}
