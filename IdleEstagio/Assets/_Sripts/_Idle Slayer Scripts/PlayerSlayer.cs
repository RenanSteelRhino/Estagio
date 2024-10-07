using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerSlayer : MonoBehaviour
{
    Animator anim;
    [SerializeField] bool isEnemyNearby;
    [SerializeField] bool isPlayerAttacking;
    [SerializeField] LayerMask enemyLayerMask;
    public static event Action<bool> CanMove;
    EnemyTakeDamage currentEnemy = null;

    CancellationTokenSource _tokenSource;

    private void Awake() 
    {
        anim = GetComponent<Animator>();
    }

    private async Task AttackEnemy()
    {
        isPlayerAttacking = true;

        _tokenSource = new CancellationTokenSource();
        var token = _tokenSource.Token;

        while(isEnemyNearby)
        {
            if(token.IsCancellationRequested) 
            {
                Debug.Log("Cancelled");
                return;
            }

            string animName = UnityEngine.Random.Range(0f,100f) >= 50 ? "Atk1" : UnityEngine.Random.Range(0f,100f) >= 50 ? "Atk2" : "Atk3";
            anim.Play(animName);

            await Task.Delay(3 * 100);
            if(currentEnemy != null)
                currentEnemy.TakeDamage();

            await Task.Delay(2 * 1000);
        }
    }

    private void Update() 
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1, enemyLayerMask);

        if(hit)
        {
            Debug.DrawRay(transform.position, Vector2.right*1, Color.green);
            currentEnemy = hit.collider.gameObject.GetComponent<EnemyTakeDamage>();
            isEnemyNearby = true;

            if(!isPlayerAttacking)
            {
                CanMove?.Invoke(false);
                AttackEnemy();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.right*1, Color.red);
            if(isPlayerAttacking)
            {
                //Cancela a task
                CanMove?.Invoke(true);
                _tokenSource.Cancel();
                anim.Play("Walk");
                isPlayerAttacking = false;
            }

            isEnemyNearby = false;
        }
    }
}
