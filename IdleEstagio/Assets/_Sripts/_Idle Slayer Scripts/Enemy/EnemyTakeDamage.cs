using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(EnemyLife))]
public class EnemyTakeDamage : EnemyBase
{
    [Header("Vfx Options")]
    public List<GameObject> vfxs = new List<GameObject>();
    [SerializeField] private float vfxDuration = 0.333f;
    [SerializeField] private Vector2 vfxMovement;
    EnemyLife lifeScript;

    protected override void Awake() 
    {
        base.Awake();
        lifeScript = GetComponent<EnemyLife>();
    }

    public void TakeDamage()
    {
        HitVFX();
        lifeScript.TakeDamage();
    }

    private void HitVFX()
    {
        anim.Play("Hit");

        for (int i = 0; i < vfxs.Count; i++)
        {
            GameObject obj = Instantiate(vfxs[i], transform);

            Vector3 movement = new Vector3(
                Random.Range(vfxMovement.x/3,vfxMovement.x),
                Random.Range(vfxMovement.y/3,vfxMovement.y),
                0) + transform.position;

            obj.transform.DOMove(movement, vfxDuration).OnComplete( ()=>
            {
                Destroy(obj);
            } );
        }
    }
}
