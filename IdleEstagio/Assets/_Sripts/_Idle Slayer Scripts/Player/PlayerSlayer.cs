using System;
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
        // Guarda o componente animator dentro da variavel anim.
        anim = GetComponent<Animator>();
    }

    // Função que faz o personagem atacar o inimigo
    // Funcina tanto a animação como o dano em si
    private async Task AttackEnemy()
    {
        // Coloca o estado do personagem como Atacando
        isPlayerAttacking = true;

        _tokenSource = new CancellationTokenSource();
        var token = _tokenSource.Token;

        // Enquanto o inimigo estiver proximo do personagem
        while(isEnemyNearby)
        {
            if(token.IsCancellationRequested) 
            {
                Debug.Log("Cancelled");
                return;
            }

            // Pegar uma animação de ataque randomica entre as 3 que o personagem possui
            string animName = UnityEngine.Random.Range(0f,100f) >= 50 ? "Atk1" : 
                              UnityEngine.Random.Range(0f,100f) >= 50 ? "Atk2" : "Atk3";
            
            // To dando play na animação
            anim.Play(animName);

            //Delay de 300 ms = 0.3 segundos
            await Task.Delay(3 * 100);

            // Se houver inimigos dentro dessa variavel, ele vai tomar dano
            if(currentEnemy != null)
                currentEnemy.TakeDamage();

            // Delay de 2 segundos 2000 ms
            await Task.Delay(2 * 1000);
        }
    }

    private void Update() 
    {
        // Linha imaginaira que acerta o inimigo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1, enemyLayerMask);

        if(hit)
        {
            Debug.DrawRay(transform.position, Vector2.right*1, Color.green);

            // Guarda o inimigo dentro da variavel currentEnemy
            currentEnemy = hit.collider.gameObject.GetComponent<EnemyTakeDamage>();
            // Seta o estado para InimigoProximo
            isEnemyNearby = true;

            // Se eu n estiver atacando atualmente, começa uma nova rotina de ataque
            if(!isPlayerAttacking)
            {
                // Manda um evento para todo mundo saber que a hora de se mexer acabou, agora devo atacar
                CanMove?.Invoke(false);
                AttackEnemy();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.right*1, Color.red);

            if(isPlayerAttacking)
            {
                // O ataque acabou, pode mandar o evento para todos voltarem a mexer
                CanMove?.Invoke(true);
                // Cancela a task
                _tokenSource.Cancel();
                // Vou resetar a animação para a animação de walk
                anim.Play("Walk");
                // Seta o estado de Atacando para false
                isPlayerAttacking = false;

            }

            // Seta false porque n tem nenhum inimigo proximo
            isEnemyNearby = false;
        }
    }
}
