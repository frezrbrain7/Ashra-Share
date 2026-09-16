using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float chaseSpeed = 5f;
    public float returnSpeed = 4f;

    public float detectionRange = 7f;
    public float attackRange = 1.2f;
    public int damage = 10;
    public float attackCooldown = 1f;

    public Vector2 homePosition;
    public float roamRadius = 15f;
    public float maxRoamRadius = 50f;
    public float chaseCooldown = 5f;


    private float nextChaseTime;
    private float nextAttackTime;
    private Transform player;
    private Vector2 moveDirection;
    private float changeDirectionTimer;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        PickNewDirection();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        homePosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        float distanceFromHome = Vector2.Distance(transform.position, homePosition);

        // 1. Attack (highest priority)
        if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
            return;
        }

        // 2. If too far from home → return immediately
        else if (distanceFromHome > maxRoamRadius)
        {
            ReturnHome();
            return;
        }

        // 3. Chase player if in range
        else if ((distanceToPlayer <= detectionRange) && (Time.time >= nextChaseTime))
        {
        
        
            ChasePlayer();
            return;
        }

        // 4. Otherwise wander
        else 
        {
        Wander();
        }
    }


    void AttackPlayer()
    {
        if (Time.time >= nextAttackTime)
        {

            nextAttackTime =
                Time.time + attackCooldown;
            
            animator.SetTrigger("Attack");
        }
    }

    void ReturnHome()
    {
        Vector2 direction =
            (homePosition - (Vector2)transform.position).normalized;
        
        nextChaseTime =
                Time.time + chaseCooldown;

        Move(direction, returnSpeed);
    }

    void ChasePlayer()
    {
        Vector2 direction =
            (player.position - transform.position).normalized;

         Move(direction, chaseSpeed);
    }

    void Wander()
    {
        Vector2 nextPosition = 
            (Vector2)transform.position + moveDirection * moveSpeed * Time.deltaTime;

        if (Vector2.Distance(nextPosition, homePosition) > roamRadius)
        {
            // steer back toward home
            moveDirection = (homePosition - (Vector2)transform.position).normalized;
        }

        changeDirectionTimer -= Time.deltaTime;

        if (changeDirectionTimer <= 0)
        {
            PickNewDirection();
        }

        Move(moveDirection, moveSpeed);
    }

    void Move(Vector2 direction, float speed)
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        if (direction.x < 0)
            spriteRenderer.flipX = true;
        else if (direction.x > 0)
            spriteRenderer.flipX = false;

        animator.SetBool("isMoving", direction != Vector2.zero);
    }
    
    public void DealAttackDamage()
    {
        //Debug.Log("Bandit dealt damage!");

        Health health =
            player.GetComponent<Health>();

        //Debug.Log("Health component found: " + (health != null));

        health?.TakeDamage(damage);
    }

    void PickNewDirection()
    {
        moveDirection = Random.insideUnitCircle.normalized;
        changeDirectionTimer = Random.Range(2f, 4f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(homePosition, roamRadius);
    }
}