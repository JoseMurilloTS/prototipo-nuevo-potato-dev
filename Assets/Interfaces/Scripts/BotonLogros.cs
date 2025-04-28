using UnityEngine;

public class AccionBotonLogros : MonoBehaviour
{
    public GameObject panelLogros;
    public AudioSource audioSource;
    public AudioClip sonidoClick;
    public float delay = 0.3f;

    public void MostrarLogros()
    {
        if (audioSource != null && sonidoClick != null)
            audioSource.PlayOneShot(sonidoClick);

        if (panelLogros != null)
            panelLogros.SetActive(true);
    }

    public void OcultarLogros()
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
        if (panelLogros != null)
            panelLogros.SetActive(false);
    }
}
