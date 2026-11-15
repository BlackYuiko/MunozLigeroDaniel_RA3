using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [Header("Fuentes de Audio")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Clips de Audio")]
    [SerializeField] private AudioClip BackgroundMusic;
    [SerializeField] private AudioClip gravityBoing;
    [SerializeField] private AudioClip deathFAH;
    [SerializeField] private AudioClip levelClink;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if (Instance != null && Instance != this) return;

        GameEvents.OnGravityBoing += DoGravityBoing;
        GameEvents.OnDeathFAH += DoDeathFAH;
        GameEvents.OnLevelClink += DoLevelClink;
    }

    private void OnDisable()
    {
        if (Instance != null && Instance != this) return;

        GameEvents.OnGravityBoing -= DoGravityBoing;
        GameEvents.OnDeathFAH -= DoDeathFAH;
        GameEvents.OnLevelClink -= DoLevelClink;
    }

    private void Start()
    {
        if (BackgroundMusic != null && !musicSource.isPlaying)
        {
            musicSource.clip = BackgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    private void DoGravityBoing() => DoSFX(gravityBoing);
    private void DoDeathFAH() => DoSFX(deathFAH);
    private void DoLevelClink() => DoSFX(levelClink);

    private void DoSFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
