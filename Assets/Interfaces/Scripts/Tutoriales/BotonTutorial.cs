using UnityEngine;

public class AccionBotonTutorial : MonoBehaviour
{
    public GameObject panelTutorial;
    public AudioSource audioSource;
    public AudioClip sonidoClick;
    public float delay = 0.3f;

    public void MostrarTutorial()
    {
        if (audioSource != null && sonidoClick != null)
        {
            audioSource.PlayOneShot(sonidoClick);
        }

        if (panelTutorial != null)
        {
            panelTutorial.SetActive(true);
        }
    }

    public void OcultarTutorial()
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
        if (panelTutorial != null)
        {
            panelTutorial.SetActive(false);
        }
    }
}
