using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    static Timer speedUpTimer;
    static float duration;

    #region Properties
    public static float TimeLeft
    {
        get { return speedUpTimer.TimeLeft; }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        speedUpTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedUpListener(SpeedUpHandler);
    }

    // Update is called once per frame
    void SpeedUpHandler(float duration, float factor)
    {
        if (speedUpTimer.Running)
        {
            speedUpTimer.AddTime(duration);
        }
        else
        {
            speedUpTimer.Duration = duration;
            speedUpTimer.Run();
        }
    }
}
