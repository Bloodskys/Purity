using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Creature : MonoBehaviour, IDestroyable
{

    /// <summary>
    /// Maximum raw damage mount a creature must take to die
    /// </summary>
    public float Toughness
    {
        get
        {
            float total = 0;
            if (toughnessComponents == null)
            {
                toughnessComponents = new List<PointPool>() { Health };
            }
            foreach(PointPool pool in toughnessComponents)
            {
                total += pool.Value;
            }
            return total;
        }
        set
        {
            float deltaToughness = Toughness - value;
            // If you lose health
            if (deltaToughness > 0)
            {
                // Sequential decreasing toughness levels
                for (int i = 0; i < toughnessComponents.Count; i++)
                {
                    float localDelta = Mathf.Min(toughnessComponents[i].Value, deltaToughness);
                    toughnessComponents[i].Value -= localDelta;
                    deltaToughness -= localDelta;
                    if (deltaToughness <= 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                Health += deltaToughness;
            }
        }
    }

    /// <summary>
    /// Array of active effects
    /// </summary>
    public List<Effect> Effects
    {
        get
        {
            if (effects == null)
            {
                effects = new List<Effect>();
            }
            return effects;
        }
        set
        {
            effects = value;
        }
    }

    /// <summary>
    /// Health point pool
    /// </summary>
    public PointPool Health
    {
        get
        {
            return health;
        }
        set
        {
            // If [health] equals to [value] — nothing changed
            if (Health != value)
            {
                float deltaValue = value - Health;
                EnemyEventArgs e = new EnemyEventArgs()
                {
                    RawHitpoints = deltaValue
                };
                // If value <= 0 - then die
                if (value <= 0)
                {
                    Die();
                    return;
                }
                // If health decreased - then raise OnDamageTaken
                else if (deltaValue < 0)
                {
                    health -= deltaValue;
                    Raise_OnDamageTaken(e);
                }
                // If [Health] increased - then raise OnHealthRecovered
                else if (deltaValue > 0)
                {
                    // If [Health] equals to [MaxHealth] - then return
                    if (Health == MaxHealth)
                    {
                        return;
                    }
                    health = Mathf.Min(MaxHealth, Health + deltaValue);
                    Raise_OnHealthRecovered(e);
                }
                // Raise OnHealthChanged
                e.RawHitpoints = Health;
                Raise_OnHealthChanged(e);
            }
        }
    }

    /// <summary>
    /// Energy point pool
    /// </summary>
    public PointPool Energy
    {
        get
        {
            return energy;
        }
    }

    /// <summary>
    /// Life points levels
    /// </summary>
    protected List<PointPool> toughnessComponents;

    /// <summary>
    /// Array of active effects 
    /// </summary>
    protected List<Effect> effects;

    /// <summary>
    /// Maximum health points amount a creature can accumulate
    /// </summary>
    public float MaxHealth
    {
        get
        {
            return Health.MaxValue;
        }
    }

    #region EventHandlers

    public EventHandler OnDamageAttempt;
    public EventHandler OnDamageTaken;
    public EventHandler OnHealingTaken;
    public EventHandler OnHealthChanged;
    public EventHandler OnHealthRecovered;
    public EventHandler OnHealthLost;

    #endregion

    /// <summary>
    /// Creature name
    /// </summary>
    public string Name;

    /// <summary>
    /// Health component
    /// </summary>
    public PointPool health;

    /// <summary>
    /// Energy component
    /// </summary>
    public PointPool energy;

    #region Debug Fields

    //Ввод с инспектора
    public float MaxHP;

    //Вывод на инспектор
    public float CurrentHealth;

    #endregion

    private void Start()
    {
        health = MaxHP;
    }

    void Update()
    {
        TickEffects();

        // Отображение здоровья в инспекторе
        CurrentHealth = Health;
    }

    /// <summary>
    /// Destroys the creature
    /// </summary>
    public void Destroy()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Takes damage points
    /// </summary>
    /// <param name="attacker">Attacker</param>
    /// <param name="damage">Damage amount</param>
    public void TakeDamage(Effect effect, float damage)
    {
        EnemyEventArgs e = new EnemyEventArgs()
        {
            Enemy = effect.Actor,
            Source = new InfluenceSource()
            {
                Effect = effect,
                Type = InfluenceSource.InfluenceType.Damage,
                RawHitpoints = damage
            }
        };
        Raise_OnDamageAttempt(e);
        if (damage != 0)
        {
            Toughness -= damage;
        }
    }

    /// <summary>
    /// Takes healing from source
    /// </summary>
    /// <param name="healer">Caster</param>
    /// <param name="health">Healing</param>
    public void TakeHealing(Effect effect, float health)
    {
        EnemyEventArgs e = new EnemyEventArgs()
        {
            Enemy = effect.Actor,
            Source = new InfluenceSource()
            {

            }
        };
        RecoverHealth(health);
        Raise_OnHealingTaken(e);
    }

    /// <summary>
    /// Recovers health points
    /// </summary>
    /// <param name="health">Recovered health points amount</param>
    public void RecoverHealth(float health)
    {
        Health += health;
    }

    /// <summary>
    /// Removes target effect
    /// </summary>
    /// <param name="effect"></param>
    public void RemoveEffect(Effect effect)
    {
        effects.Remove(effect);
    }

    /// <summary>
    /// Triggers each [effect behaviour]
    /// </summary>
    protected void TickEffects()
    {
        for (int i = 0; i < Effects.Count; i++)
        {
            Effects[i].Tick();
        }
    }

    /// <summary>
    ///  Triggers whenever creature recovers health points
    /// </summary>
    /// <param name="e">Recovered health points amount in Args[0]</param>
    protected void Raise_OnHealthRecovered(EnemyEventArgs e)
    {
        Debug.Log("Triggered: OnHelthRecovered [" + e.RawHitpoints + "]");
        if (OnHealthRecovered != null)
        {
            OnHealthRecovered.Invoke(this, e);
        }
    }

    /// <summary>
    /// Triggers whenever creature gets damage
    /// </summary>
    /// <param name="e">Damage amount in Args[0]</param>
    protected void Raise_OnDamageTaken(EnemyEventArgs e)
    {
        Debug.Log("Triggered: OnDamageTaken [" + e.RawHitpoints + "]");
        if (OnDamageTaken != null)
        {
            OnDamageTaken.Invoke(this, e);
        }
    }

    /// <summary>
    /// Triggers whenever something tries to hurt you (even if you didn't take damage)
    /// </summary>
    protected void Raise_OnDamageAttempt(EnemyEventArgs e)
    {
        Debug.Log("Triggered: OnDamageAttempt [" + e.RawHitpoints + "]");
        if (OnDamageAttempt != null)
        {
            OnDamageAttempt.Invoke(this, e);
        }
    }

    /// <summary>
    /// Triggers whenever creature gets healing (even if creature doesn't recover health)
    /// </summary>
    /// <param name="e">Health points amount in Args[0]</param>
    protected void Raise_OnHealingTaken(EnemyEventArgs e)
    {
        Debug.Log("Triggered: OnHealingTaken [" + e.RawHitpoints + "]");
        if (OnHealingTaken != null)
        {
            OnHealingTaken.Invoke(this, e);
        }
    }

    /// <summary>
    /// Triggers whenever creature health changed
    /// </summary>
    /// <param name="e">Empty args</param>
    protected void Raise_OnHealthChanged(EventArgs e)
    {
        Debug.Log("Triggered: OnHealthChanged");
        if (OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(this, e);
        }
    }

    /// <summary>
    /// Triggers whenever creature recovers any health
    /// </summary>
    /// <param name="e">Empty args</param>
    protected void Raise_OnHealthRecovered(EventArgs e)
    {
        Debug.Log("Triggered: OnHealthRecovered");
        if (OnHealthRecovered != null)
        {
            OnHealthRecovered.Invoke(this, e);
        }
    }

    /// <summary>
    /// Triggers whenever creature loses any health
    /// </summary>
    /// <param name="e">Empty args</param>
    protected void Raise_OnHealthLost(EventArgs e)
    {
        Debug.Log("Triggered: OnHealthLost");
        if (OnHealthLost != null)
        {
            OnHealthLost.Invoke(this, e);
        }
    }

    /// <summary>
    /// Destroy creature
    /// </summary>
    protected void Die()
    {
        Debug.Log(Name + " died!");
        Destroy();
    }
}
