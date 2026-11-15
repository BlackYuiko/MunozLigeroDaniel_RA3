using System;

public static class GameEvents
{
    public static event Action OnGravityBoing;
    public static event Action OnDeathFAH;
    public static event Action OnLevelClink;

    public static void PlayGravityBoing() => OnGravityBoing?.Invoke();
    public static void PlayDeathFAH() => OnDeathFAH?.Invoke();
    public static void PlayLevelClink() => OnLevelClink?.Invoke();
}