using UnityEngine;

public class ScriptSaltar : MonoBehaviour
{
    public GameObject panelTutorial;
    public AudioSource audioSource;
    public AudioClip sonidoClick;
    public float delay = 0.3f;

    public void SaltarTutorial()
    {
        if (audioSource != null && sonidoClick != null)
        {
            audioSource.PlayOneShot(sonidoClick);
        }

        Invoke(nameof(CerrarTutorial), delay);
    }

    private void CerrarTutorial()
    {
        if (panelTutorial != null)
            panelTutorial.SetActive(false);
    }
}
