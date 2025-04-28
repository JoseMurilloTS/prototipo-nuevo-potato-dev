using UnityEngine;
using UnityEngine.UI;

public class DesbloqueoLogros : MonoBehaviour
{
    [System.Serializable]
    public class Logro
    {
        public GameObject filtroOscuro;        // El filtro/capa negra sobre la imagen
        public string nombreClavePlayerPrefs;  // Ej: "logro_nivel_1"
    }

    public Logro[] logros;

    private void Start()
    {
        ActualizarEstadoLogros();
    }

    public void ActualizarEstadoLogros()
    {
        foreach (Logro logro in logros)
        {
            bool desbloqueado = PlayerPrefs.GetInt(logro.nombreClavePlayerPrefs, 0) == 1;

            if (logro.filtroOscuro != null)
                logro.filtroOscuro.SetActive(!desbloqueado); // Apagamos filtro si está desbloqueado
        }
    }

    public static void DesbloquearLogro(string nombreClave)
    {
        PlayerPrefs.SetInt(nombreClave, 1);
        PlayerPrefs.Save();
    }
}
