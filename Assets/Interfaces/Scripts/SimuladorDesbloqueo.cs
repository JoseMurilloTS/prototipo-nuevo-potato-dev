using UnityEngine;
using UnityEngine.SceneManagement;

public class SimuladorDesbloqueo : MonoBehaviour
{
    public void DesbloquearNiveles()
    {
        PlayerPrefs.SetInt("nivel_2_desbloqueado", 1);
        PlayerPrefs.SetInt("nivel_3_desbloqueado", 1);
        PlayerPrefs.Save();

        // Ir al mapa de niveles después de desbloquear
        SceneManager.LoadScene("Mapa");
    }
}
