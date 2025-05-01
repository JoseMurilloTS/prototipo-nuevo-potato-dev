using UnityEngine;

public class ReproducirSonidoBoton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoClick;

    public void ReproducirSonido()
    {
        if (audioSource != null && sonidoClick != null)
            audioSource.PlayOneShot(sonidoClick);
    }
}
