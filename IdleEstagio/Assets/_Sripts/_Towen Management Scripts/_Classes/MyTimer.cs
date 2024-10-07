using System;

public class MyTimer
{
    public float duration;
    float baseDuration;
    public event Action OnTimerEnd;
    public bool isLooping;
    private bool timerEnded;

    public void InitializeTimer(float _duration, bool _isLooping)
    {
        duration = _duration;
        baseDuration = _duration;
        isLooping = _isLooping;
    }

    public void TickTimer(float tickSpeed)
    {
        if(timerEnded) return;

        duration -= tickSpeed;

        if(duration <= 0)
            TimerEnded();
    }

    public void TimerEnded()
    {
        OnTimerEnd?.Invoke();

        if(isLooping)
        {
            duration = baseDuration;
            timerEnded = false;
        }
        else
            timerEnded = true;
    }
}
