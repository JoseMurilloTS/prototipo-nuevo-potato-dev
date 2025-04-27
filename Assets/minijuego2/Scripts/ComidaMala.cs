using UnityEngine;

public class ComidaMala : MonoBehaviour
{
    public AudioClip sonidoChoque;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.RestarVida(); // Resta 1 vida
            Destroy(gameObject); // Elimina el objeto "malo"
            AudioManager.Instance.ReproducirSonido(sonidoChoque); // Opcional
        }
    }
}
