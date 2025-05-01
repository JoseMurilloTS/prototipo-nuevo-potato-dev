using UnityEngine;

public class ScriptAnterior : MonoBehaviour
{
    public GameObject panelActual;
    public GameObject panelAnterior;
    public AudioSource audioSource;
    public AudioClip sonidoClick;
    public float delay = 0.3f;

    public void Retroceder()
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

        if (panelAnterior != null)
            panelAnterior.SetActive(true);
    }
}
