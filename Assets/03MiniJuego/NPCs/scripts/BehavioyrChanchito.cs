using UnityEngine;

public class BehavioyrChanchito : MonoBehaviour
{
 
    [SerializeField] private float moveSpeed = 2f;      // Velocidad de movimiento
    [SerializeField] private float changeDirectionTime = 3f; // Cada cuánto cambia de dirección
    private Vector2 randomDirection;                    // Dirección aleatoria actual
    private float timer;                                // Temporizador para cambio de dirección
    private bool isCaught = false;                      // ¿Lo atrapó el jugador?
    private int puntajeChancho=50;
    private Rigidbody2D rb;

    public int PuntajeChancho { get => puntajeChancho; set => puntajeChancho = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PickNewDirection(); // Inicia con una dirección aleatoria
    }

    private void Update()
    {
        if (isCaught) return; // Si lo atrapan, no se mueve más

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            PickNewDirection(); // Cambia de dirección cada cierto tiempo
        }

        MoveChanchito();
    }

    private void PickNewDirection()
    {
        randomDirection = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized; // Normalizado para que no vaya más rápido en diagonales

        timer = changeDirectionTime; // Reinicia el temporizador
    }

    private void MoveChanchito()
    {
        rb.linearVelocity = randomDirection * moveSpeed; // Mueve al chanchito
    }

    // Cuando el jugador lo atrape (desde el script del jugador o colisión)
    public void Catch(Transform manosJugador)
    {
        isCaught = true;
        rb.linearVelocity = Vector2.zero; // Detiene el movimiento
        rb.bodyType=RigidbodyType2D.Kinematic;
        transform.SetParent(manosJugador); // Lo hace hijo del jugador
        transform.localPosition = Vector3.zero; // Lo centra en las "manos"
        GetComponent<Collider2D>().enabled = false;
    }

    public void Release()
    {
        isCaught = true;
        transform.SetParent(null); // Lo libera del jugador
        GetComponent<Collider2D>().enabled = true; // Reactiva el collider
        rb.bodyType = RigidbodyType2D.Dynamic; // Vuelve a ser afectado por físicas
        rb.linearVelocity=Vector2.zero;
    }
}
