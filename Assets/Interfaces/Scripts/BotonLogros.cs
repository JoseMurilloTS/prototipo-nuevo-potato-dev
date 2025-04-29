using UnityEngine;

public class AccionBotonLogros : MonoBehaviour
{
    public GameObject panelLogros;  // Panel que muestra los logros
    public GameObject iconoNuevoLogro; // El icono "!" en el botón de logros
    public AudioSource audioSource;
    public AudioClip sonidoClick;
    public float delay = 0.3f;

    void Start()
    {
        // Verificar si hay un nuevo logro y mostrar el icono "!"
        if (PlayerPrefs.GetInt("nuevo_logro", 0) == 1)
        {
            iconoNuevoLogro.SetActive(true); // Mostrar el icono
        }
        else
        {
            iconoNuevoLogro.SetActive(false); // Asegurarse de que el icono esté oculto si no hay logros nuevos
        }
    }

    // Mostrar el panel de logros
    public void MostrarLogros()
    {
        if (audioSource != null && sonidoClick != null)
            audioSource.PlayOneShot(sonidoClick);

        if (panelLogros != null)
            panelLogros.SetActive(true);

        // Cuando se abran los logros, se debe resetear el indicador de nuevo logro
        AlAbrirLogros();
    }

    // Ocultar el panel de logros
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

    // Desactivar el panel de logros
    private void DesactivarPanel()
    {
        if (panelLogros != null)
            panelLogros.SetActive(false);
    }

    // Este método se llama cuando se abren los logros
    private void AlAbrirLogros()
    {
        PlayerPrefs.SetInt("nuevo_logro", 0); // Reseteamos el estado de "nuevo logro"
        PlayerPrefs.Save();

        // Ocultamos el icono "!" cuando el jugador ve los logros
        iconoNuevoLogro.SetActive(false);
    }
}
