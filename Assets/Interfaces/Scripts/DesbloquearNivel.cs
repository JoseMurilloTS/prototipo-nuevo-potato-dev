using UnityEngine;
using UnityEngine.UI;

public class DesbloqueoNiveles : MonoBehaviour
{
    [System.Serializable]
    public class Nivel
    {
        public Button botonNivel;
        public string nombreClavePlayerPrefs; // Ej: "nivel_2_desbloqueado"
        public GameObject iconoBloqueado;     // Imagen del candado u overlay
    }

    public Nivel[] niveles;

    private void Start()
    {
        PlayerPrefs.SetInt("nivel_1_desbloqueado", 1);

        ActualizarEstadoNiveles();
    }

    public void ActualizarEstadoNiveles()
    {
        foreach (Nivel nivel in niveles)
        {
            bool desbloqueado = PlayerPrefs.GetInt(nivel.nombreClavePlayerPrefs, 0) == 1;

            nivel.botonNivel.interactable = desbloqueado;

            if (nivel.iconoBloqueado != null)
                nivel.iconoBloqueado.SetActive(!desbloqueado);
        }
    }

    // Esto lo usarás más adelante desde otras escenas
    public static void DesbloquearNivel(string nombreClave)
    {
        PlayerPrefs.SetInt(nombreClave, 1);
        PlayerPrefs.Save();
    }
}
