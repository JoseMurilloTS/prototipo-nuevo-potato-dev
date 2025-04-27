using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionBotonJugar : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public float delayAntesDeCargar = 0.3f;

    public void CargarMapa()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            Invoke("CargarEscena", delayAntesDeCargar);
        }
        else
        {
            // Si no hay sonido, carga de inmediato
            CargarEscena();
        }
    }

    void CargarEscena()
    {
        SceneManager.LoadScene("Mapa");
    }
}
