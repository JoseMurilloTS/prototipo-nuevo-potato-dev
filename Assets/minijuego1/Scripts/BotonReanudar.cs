using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonReanudar : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoClick;
    public float delay = 0.3f;

    public GameObject menuPausaUI;

    public void Reanudar()
    {
        if (audioSource && sonidoClick)
        {
            audioSource.PlayOneShot(sonidoClick);
            Invoke(nameof(ActivarJuego), delay);
        }
        else
        {
            ActivarJuego();
        }
    }

    void ActivarJuego()
    {
        menuPausaUI.SetActive(false);
    }
}
