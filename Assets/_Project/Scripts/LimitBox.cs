using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.root.CompareTag("Player"))
        {
            GameEvents.PlayLevelClink();
            SceneController.Instance.LoadNextScene();
        }
    }
}
