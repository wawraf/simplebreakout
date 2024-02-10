using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    /// <summary>
    /// Ball class
    /// </summary>
    /// 
    Rigidbody2D rb2d;

    const float StartAngle = Mathf.Deg2Rad * 270;

    Timer deathTimer;
    Timer waitTimer;
    bool fired = false;

    BallDiedEvent ballDiedEvent = new BallDiedEvent();
    BallLostEvent ballLostEvent = new BallLostEvent();

    Timer speedUpTimer;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddBallDiedInvoker(this);
        EventManager.AddBallLostInvoker(this);

        rb2d = GetComponent<Rigidbody2D>();
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifetime;
        deathTimer.Run();
        deathTimer.AddTimerFinishedListener(TimerFinishedHandler);

        waitTimer = gameObject.AddComponent<Timer>();
        waitTimer.Duration = 1f;
        waitTimer.Run();

        EventManager.AddSpeedUpListener(SpeedUp);
        speedUpTimer = gameObject.AddComponent<Timer>();
        speedUpTimer.AddTimerFinishedListener(SpeedDown);
    }

    void Update()
    {
        if (waitTimer.Finished & !fired)
        {
            fired = true;
            AddForce();
        }
    }

    void OnBecameInvisible()
    {
        if (!deathTimer.Finished)
        {
            if (gameObject.transform.position.y < ScreenUtils.ScreenBottom)
            {
                ballLostEvent.Invoke();
            }
            DestroyBall();
        }
    }

    void DestroyBall()
    {
        EventManager.RemoveBallDiedInvoker(this);
        EventManager.RemoveBallLostInvoker(this);
        Destroy(gameObject);
    }


    public void SetDirection(Vector2 direction)
    {
        rb2d.velocity = direction * rb2d.velocity.magnitude;
    }

    private void AddForce()
    {
        float force = ConfigurationUtils.BallImpulseForce;
        if (EffectUtils.TimeLeft > 0)
        {
            speedUpTimer.Duration = EffectUtils.TimeLeft;
            speedUpTimer.Run();
            force *= ConfigurationUtils.SpeedUpEffectFactor;
        }

        rb2d.AddForce(
            new Vector2(Mathf.Cos(StartAngle), Mathf.Sin(StartAngle)) * force,
            ForceMode2D.Impulse
        );
    }

    public void AddBallDiedListener(UnityAction listener)
    {
        ballDiedEvent.AddListener(listener);
    }
    public void AddBallLostListener(UnityAction listener)
    {
        ballLostEvent.AddListener(listener);
    }


    void TimerFinishedHandler()
    {
        ballDiedEvent.Invoke();
        DestroyBall();
    }

    void SpeedUp(float duration, float factor)
    {
        if (speedUpTimer.Running)
        {
            speedUpTimer.AddTime(duration);
        }
        else
        {
            speedUpTimer.Duration = duration;
            speedUpTimer.Run();
            rb2d.velocity *= ConfigurationUtils.SpeedUpEffectFactor;
        }
    }

    void SpeedDown()
    {
        AudioManager.Play(AudioName.SpeedDown);
        rb2d.velocity /= ConfigurationUtils.SpeedUpEffectFactor;
    }

}
