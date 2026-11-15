using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.root.CompareTag("Player"))
        {
            GameEvents.PlayDeathFAH();
            SceneController.Instance.LoadMenuDeath();
        }
    }
}
