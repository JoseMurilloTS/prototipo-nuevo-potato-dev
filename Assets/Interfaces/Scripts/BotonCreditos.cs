using UnityEngine;

public class AccionBotonCreditos : MonoBehaviour
{
    public GameObject imagenCreditos;
    public AudioSource audioSource;
    public AudioClip sonidoClick;
    public float delay = 0.3f; // Puedes ajustarlo si el sonido dura más o menos

    public void MostrarCreditos()
    {
        if (audioSource != null && sonidoClick != null)
            audioSource.PlayOneShot(sonidoClick);

        if (imagenCreditos != null)
            imagenCreditos.SetActive(true);
    }

    public void OcultarCreditos()
    {
        if (audioSource != null && sonidoClick != null)
        {
            audioSource.PlayOneShot(sonidoClick);
            Invoke(nameof(DesactivarPanel), delay);
        }
        else
        {
            DesactivarPanel();
        }
    }

    private void DesactivarPanel()
    {
        if (imagenCreditos != null)
            imagenCreditos.SetActive(false);
    }
}
