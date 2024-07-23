using UnityEngine;

public class PauseTimer : MonoBehaviour
{
    [Header("Settings")]
    private bool isTimerPaused;
    public bool IsTimerPaused { get { return isTimerPaused; } }

    public void StopTimer()
    {
        isTimerPaused = true;
    }

    public void PlayTimer()
    { 
        isTimerPaused = false;
    }
}
