using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI mensaje;
    public AudioSource peligro;

    private int vidasAnteriores;
    private int puntosAnteriores;

    void Start()
    {
        vidasAnteriores = GameManager.Instance.Vidas;
        puntosAnteriores = GameManager.Instance.PuntosTotales;
    }

    void Update()
    {
        
        puntos.text = "Puntos: " + GameManager.Instance.PuntosTotales.ToString();
        vidas.text = "Vidas: " + GameManager.Instance.Vidas.ToString();

        
        int vidasActuales = GameManager.Instance.Vidas;
        int puntosActuales = GameManager.Instance.PuntosTotales;

        if (vidasActuales < vidasAnteriores)
        {
            mensaje.text = "¡Cuidado!";
            Debug.Log("cuidado");
        }
        else if (puntosActuales > puntosAnteriores)
        {
            mensaje.text = "¡Lo haces bien!";
            Debug.Log("lo haces bien ");
        }

        if (vidasActuales == 1)
        {
            mensaje.text = "¡Estás a punto de perder!";
            if (!peligro.isPlaying)
                peligro.Play();
            Debug.Log("estas por perder");
        }

        if (puntosActuales >= 18 && puntosActuales < 20)
        {
            mensaje.text = "¡Ya casi lo tienes!";
            Debug.Log("ya casi");
        }

        vidasAnteriores = vidasActuales;
        puntosAnteriores = puntosActuales;
    }

}
