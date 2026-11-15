using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movimiento")]
    private float velocidad = 2f;
    private bool empezarHaciaDerecha = true;

    [Header("Detección de Paredes")]
    [SerializeField] private Transform detectorPared;
    [SerializeField] private float radioDeteccion = 0.15f;
    [SerializeField] private LayerMask capaPared;

    private Rigidbody2D rb;
    private int direccion;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        direccion = empezarHaciaDerecha ? 1 : -1;

        if (!empezarHaciaDerecha)
        {
            Vector3 escala = transform.localScale;
            escala.x = -Mathf.Abs(escala.x);
            transform.localScale = escala;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direccion * velocidad, rb.linearVelocity.y);

        if (Physics2D.OverlapCircle(detectorPared.position, radioDeteccion, capaPared))
        {
            DarLaVuelta();
        }
    }

    private void DarLaVuelta()
    {
        direccion *= -1;

        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (SceneController.Instance != null)
            {
                GameEvents.PlayDeathFAH();
                SceneController.Instance.LoadMenuDeath();
            }
        }
    }
}
