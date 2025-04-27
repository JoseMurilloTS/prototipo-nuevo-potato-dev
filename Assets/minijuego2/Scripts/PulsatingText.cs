using UnityEngine;
using TMPro; // Asegúrate de tener TextMeshPro en tu proyecto

public class PulsatingText : MonoBehaviour
{
    public float pulseSpeed = 2f; // Velocidad del parpadeo
    public float scaleAmount = 0.1f; // Cuánto se agranda/achica

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * scaleAmount;
        transform.localScale = originalScale * scale;
    }
}
