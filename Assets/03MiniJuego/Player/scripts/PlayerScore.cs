using UnityEngine;
using TMPro;
using static DesbloqueoNiveles;
using System;
public class PlayerScore : MonoBehaviour
{
    [SerializeField] TMP_Text textScore, textLife;
    private int life=3, score=0;
    public static PlayerScore Instance; //para que el singleton sea visto de forma global
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        // Patrón Singleton para fácil acceso
        if (Instance != null && Instance!= this)
        {
            Destroy(this);
            //DontDestroyOnLoad(gameObject); // Opcional: si quieres persistir entre escenas
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void UpdateUI()
    {
        if (textScore != null)
            textScore.text = "Puntos: " + score.ToString();

        if (textLife != null)
            textLife.text = "Vidas: " + life.ToString();
    }
    public void perderVida()
    {
        life -= 1;
        UpdateUI();
        if (life <= 0)
        {
            Debug.Log("perdiste");//cambiar por cambio de escena "perder"
        }
    }
    public void GanarPuntos(int puntosGanados)
    {
        score += puntosGanados;
        UpdateUI() ;
    }
}
