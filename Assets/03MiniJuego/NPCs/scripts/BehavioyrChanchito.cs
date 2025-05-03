using UnityEngine;

public class BehavioyrChanchito : MonoBehaviour
{
 
    [SerializeField] private float moveSpeed = 2f;      // Velocidad de movimiento
    [SerializeField] private float changeDirectionTime = 3f; // Cada cu�nto cambia de direcci�n
    private Vector2 randomDirection;                    // Direcci�n aleatoria actual
    private float timer;                                // Temporizador para cambio de direcci�n
    private bool isCaught = false;                      // �Lo atrap� el jugador?
    private int puntajeChancho=50;
    private Rigidbody2D rb;

    public int PuntajeChancho { get => puntajeChancho; set => puntajeChancho = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PickNewDirection(); // Inicia con una direcci�n aleatoria
    }

    private void Update()
    {
        if (isCaught) return; // Si lo atrapan, no se mueve m�s

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            PickNewDirection(); // Cambia de direcci�n cada cierto tiempo
        }

        MoveChanchito();
    }

    private void PickNewDirection()
    {
        randomDirection = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized; // Normalizado para que no vaya m�s r�pido en diagonales

        timer = changeDirectionTime; // Reinicia el temporizador
    }

    private void MoveChanchito()
    {
        rb.linearVelocity = randomDirection * moveSpeed; // Mueve al chanchito
    }

    // Cuando el jugador lo atrape (desde el script del jugador o colisi�n)
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
        rb.bodyType = RigidbodyType2D.Dynamic; // Vuelve a ser afectado por f�sicas
        rb.linearVelocity=Vector2.zero;
    }
}
