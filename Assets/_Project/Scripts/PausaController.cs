using UnityEngine;

public class PausaController : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa;
    private bool estaPausado = false;

    private void Start()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TogglePausa()
    {
        if (estaPausado)
            Reanudar();
        else
            Pausar();
    }

    public void Pausar()
    {
        estaPausado = true;
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        estaPausado = false;
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
