using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDestroyable : DestroyableEntity
{
    private Image hpBar;
    private Image hurtEffect;
    private float a = 0;
    private float r = 1;

    protected override void Die()
    {
        // face se da restart frumos la scena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public override void GetHit(float dmg)
    {
        // getDamage(), cameraShake, hurtSound, poate ui de hurt directional ca in cs
        GetDamage(dmg);
        a = 0.25f;
    }

    private void Start()
    {
        hpBar = GameObject.Find("PlayerHpBar").GetComponent<Image>();
        hurtEffect = GameObject.Find("HurtUI").GetComponent<Image>();
    }

    protected override void UpdateHpBar()
    {
        // bara mare intr-o parte a ecranului (verticala), sau sus/jos (orizontala?), cu efect
        // de ecran in functie de viata
        hpBar.fillAmount = hp / initialHp;
        hpBar.color = new Color(1 - hp / initialHp, 0.8f * hp / initialHp, 0.4f * hp / initialHp);
        print(hpBar.fillAmount);
        hurtEffect.color = new Color(1, 0, 0, a);
        a -= Time.deltaTime;
    }
}