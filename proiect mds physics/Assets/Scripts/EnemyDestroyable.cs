using UnityEngine;

public class EnemyDestroyable : DestroyableEntity
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private ParticleSystem diePS;
    [SerializeField] private AudioClip hitSound;

    protected override void Die()
    {
        // face puf, tipa, si dispare
        GetComponent<AudioSource>().PlayOneShot(hitSound, 0.5f);
        Destroy(gameObject, 0.2f);
        var k = Instantiate(diePS, transform.position, Quaternion.identity);
        Destroy(k, 0.6f);
    }

    public override void GetHit(float dmg)
    {
        // particule de glont, getDamage()
        GetDamage(dmg);
        var k = Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(k, 0.5f);
        GetComponent<AudioSource>().PlayOneShot(hitSound, 0.2f);
    }

    protected override void UpdateHpBar()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(Mathf.Clamp(hp / initialHp, 0f, 1f), 0f, 0f));
    }
}