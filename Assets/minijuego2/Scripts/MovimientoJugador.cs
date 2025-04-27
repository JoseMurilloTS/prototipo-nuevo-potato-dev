using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        float movimiento = Input.GetAxisRaw("Horizontal"); // A = -1, D = 1
        transform.Translate(Vector3.right * movimiento * velocidad * Time.deltaTime);
    }
}
