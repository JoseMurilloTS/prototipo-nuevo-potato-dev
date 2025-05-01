using UnityEngine;

public class ScriptSiguiente : MonoBehaviour
{
    public GameObject panelActual;
    public GameObject panelSiguiente;
    public AudioSource audioSource;
    public AudioClip sonidoClick;
    public float delay = 0.3f;

    public void Avanzar()
    {
        if (audioSource != null && sonidoClick != null)
        {
            audioSource.PlayOneShot(sonidoClick);
        }

        Invoke(nameof(CambiarPanel), delay);
    }

    private void CambiarPanel()
    {
        if (panelActual != null)
            panelActual.SetActive(false);

        if (panelSiguiente != null)
            panelSiguiente.SetActive(true);
    }
}
