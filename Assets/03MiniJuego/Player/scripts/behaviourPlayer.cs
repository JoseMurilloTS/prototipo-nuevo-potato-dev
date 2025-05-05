using UnityEngine;

public class behaviourPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]private float velocidad;
    [SerializeField] private Vector2 direccion;
    [SerializeField] private float catchRange = 1f; // Rango para atrapar al chanchito
    [SerializeField] private LayerMask chanchitoLayer; // Capa asignada a los chanchitos
    private bool isCarryingChanchito = false;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion=new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
        if (direccion.x<0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if  (direccion.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))//logica para agarrar al chanchito
        {
            TryCatchChanchito();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            TryReleaseChanchito();
        }
    }
    private void FixedUpdate()
    {
        Rigidbody2D.MovePosition(Rigidbody2D.position+direccion*velocidad*Time.fixedDeltaTime);
    }

    //para agarrar a los chanchos

    private void TryCatchChanchito()
    {
        if (isCarryingChanchito) return; // Si ya lleva uno, no atrapa más
        // Detecta chanchitos en un círculo alrededor del jugador
        Collider2D[] nearbyChanchitos = Physics2D.OverlapCircleAll(
            transform.position,
            catchRange,
            chanchitoLayer
        );
        if (nearbyChanchitos.Length == 0) return;
        isCarryingChanchito = true; // Marca que está cargando uno
        foreach (Collider2D chanchito in nearbyChanchitos)
        {
            chanchito.GetComponent<BehavioyrChanchito>().Catch(transform.Find("Manos")); // Llama al método Catch del chanchito
            break; // Solo atrapa el primero
        }
    }
    // Método para soltar al chanchito
    private void TryReleaseChanchito()
    {
        // Busca si hay un chanchito atrapado (hijo de "Manos")
        Transform manos = transform.Find("Manos");
        if (manos == null || manos.childCount == 0) return;

        BehavioyrChanchito chanchito = manos.GetChild(0).GetComponent<BehavioyrChanchito>();
        if (chanchito != null)
        {
            chanchito.Release(); // Llama al método de liberación
            isCarryingChanchito = false; // Ya no lleva ningún chanchito
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, catchRange);
    }


}
