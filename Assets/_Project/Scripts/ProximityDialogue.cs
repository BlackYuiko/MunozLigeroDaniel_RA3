using UnityEngine;

public class ProximityDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogo;

    private void Start()
    {
        if (dialogo != null)
        {
            dialogo.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogo.SetActive(false);
        }
    }
}
