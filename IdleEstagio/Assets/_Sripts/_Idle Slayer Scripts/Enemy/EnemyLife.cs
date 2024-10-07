using UnityEngine;

public class EnemyLife : EnemyBase
{
    [SerializeField] private float currentLife = 1;

    public void TakeDamage()
    {
        currentLife -= 1;

        if (currentLife <= 0)
        {
            anim.Play("Death");
            Destroy(this.gameObject, 0.5f);
        }
    }
}
