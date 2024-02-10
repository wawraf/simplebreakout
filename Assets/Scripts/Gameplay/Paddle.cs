using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    /// <summary>
    /// Paddle behaviour
    /// </summary>
    ///

    #region Fields

    Rigidbody2D rb2d;
    Vector2 velocity;
    float colliderHalfWidth;
    float colliderHalfHeight;

    const float BounceAngleHalfRange = Mathf.Deg2Rad * 60;
    const float HitTolerance = 0.1f;

    GameObject hud;

    Timer freezeTimer;
    bool freezed;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        velocity = new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond, 0);
        colliderHalfWidth = GetComponent<BoxCollider2D>().size.x/2 * rb2d.transform.localScale.x;
        colliderHalfHeight = GetComponent<BoxCollider2D>().size.y / 2 * rb2d.transform.localScale.y;
        // find by tag hud = tag

        EventManager.AddFreezerListener(Freezed);
        freezeTimer = gameObject.AddComponent<Timer>();
        freezeTimer.AddTimerFinishedListener(ReleasedFromFreeze);
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if (move != 0 && !freezed)
        {
            Vector2 position = rb2d.position + move * velocity * Time.fixedDeltaTime;
            position.x = CalculateClampedX(position.x);
            rb2d.MovePosition(position);
        }

    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && isTopCollision(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x - coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter / colliderHalfWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    #endregion

    #region Private methods
    float CalculateClampedX(float positionX)
    {
        if (positionX > ScreenUtils.ScreenRight - colliderHalfWidth)
        {
            return ScreenUtils.ScreenRight - colliderHalfWidth;
        }
        else if (positionX < ScreenUtils.ScreenLeft + colliderHalfWidth)
        {
            return ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        return positionX;
    }

    bool isTopCollision(Collision2D coll)
    {
        ContactPoint2D[] contacts = new ContactPoint2D[2];
        coll.GetContacts(contacts);

        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < HitTolerance;
    }

    void Freezed(float duration)
    {
        if (freezeTimer.Running)
        {
            freezeTimer.AddTime(duration);
        }
        else
        {
            freezeTimer.Duration = duration;
            freezeTimer.Run();
        }
        freezed = true;
    }

    void ReleasedFromFreeze()
    {
        AudioManager.Play(AudioName.Unfreeze);
        freezed = false;
    }

    #endregion
}
