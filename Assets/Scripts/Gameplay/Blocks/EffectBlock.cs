using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectBlock : Block
{
    /// <summary>
    /// Script describing block behaviouor
    /// </summary>
    /// 

    [SerializeField]
    Sprite freezerSprite;

    [SerializeField]
    Sprite speedUpSprite;

    EffectName effectName;
    float effectDuration;
    float effectFactor;

    FreezerEffectActivatedEvent freezerEffectActivatedEvent;
    SpeedUpEffectActivatedEvent speedUpEffectActivatedEvent;

    public EffectName BlockEffectName {
        get { return effectName; }
        set { 
            effectName = value;

            if (effectName == EffectName.Freezer)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = freezerSprite;
                effectDuration = ConfigurationUtils.FreezerEffectDuration;
                freezerEffectActivatedEvent = new FreezerEffectActivatedEvent();
                EventManager.AddFreezerInvoker(this);
            }
            else if (effectName == EffectName.Speedup)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = speedUpSprite;
                effectDuration = ConfigurationUtils.SpeedUpEffectDuration;
                effectFactor = ConfigurationUtils.SpeedUpEffectFactor;
                speedUpEffectActivatedEvent = new SpeedUpEffectActivatedEvent();
                EventManager.AddSpeedUpInvoker(this);
            }
        }
    }

    override protected void Start()
    {
        base.Start();

        Points = ConfigurationUtils.EffectBlockPoints;
    }
    override protected void OnCollisionEnter2D(Collision2D col)
    {
        if (BlockEffectName == EffectName.Freezer)
        {
            AudioManager.Play(AudioName.Freeze);
            freezerEffectActivatedEvent.Invoke(effectDuration);
            EventManager.RemoveFreezeInvoker(this);
        }
        else if (BlockEffectName == EffectName.Speedup)
        {
            AudioManager.Play(AudioName.SpeedUp);
            speedUpEffectActivatedEvent.Invoke(effectDuration, effectFactor);
            EventManager.RemoveSpeedUpInvoker(this);
        }
        base.OnCollisionEnter2D(col);
    }

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivatedEvent.AddListener(listener);
    }
    public void AddSpeedUpEffectListener(UnityAction<float, float> listener)
    {
        speedUpEffectActivatedEvent.AddListener(listener);
    }
}
