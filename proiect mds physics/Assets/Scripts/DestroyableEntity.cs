using UnityEngine;

public abstract class DestroyableEntity : MonoBehaviour
{
    [SerializeField] protected float hp = 100f;
    protected float initialHp;
    [SerializeField] private float hpRegenPerSecond = 1f;

    protected abstract void Die();

    public abstract void GetHit(float dmg);  //implementation of subclasses will call GetDamage

    protected void GetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
            Die();
    }

    private void Update()
    {
        hp = Mathf.Clamp(hp + hpRegenPerSecond * Time.deltaTime, -1, initialHp);
    }

    private void Awake()
    {
        initialHp = hp;
    }

    protected abstract void UpdateHpBar();

    private void FixedUpdate()
    {
        UpdateHpBar();
    }
}