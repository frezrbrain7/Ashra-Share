using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackUpdate : MonoBehaviour
{
    public float woodAttackRange = 1.5f;
    public float woodAttackWidth = 1f;
    public int woodDamage = 10;
    public float woodAttackCooldown = 0.29f;
    public float stoneAttackRange = 1.8f;
    public float stoneAttackWidth = 1.4f;
    public int stoneDamage = 20;
    public float stoneAttackCooldown = 0.6f;
    private float nextAttackTime = 0f;
    private Vector2 moveDir;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float attackRange;
    private float attackWidth;
    private int damage;
    private float attackCooldown;
    private string swordType = "Wood";

    public Vector2 attackDir;

    private PlayerHealth playerHealth;

    public LayerMask enemyLayer;
    public bool IsBlocking { get; private set; }
    public bool isAttacking, hasAttackFired;
    private float attackTimeCooldown = 0.29f;


    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerHealth = GetComponent<PlayerHealth>();

        attackRange = woodAttackRange;
        attackWidth = woodAttackWidth;
        damage = woodDamage;
        attackCooldown = woodAttackCooldown;

        isAttacking = false;
        hasAttackFired = false;
    }

    bool CanAttack()
    {
        return Time.time >= nextAttackTime;
    }

    public void AttackFinished()
    {
        isAttacking = false;
        hasAttackFired = false;
    }

    void Update()
    {
        IsBlocking = Mouse.current != null && Mouse.current.rightButton.isPressed;
        animator.SetBool("IsBlocking", IsBlocking);

        if (playerHealth.HasStoneSword("Stone"))
        {
            attackRange = stoneAttackRange;
            attackWidth = stoneAttackWidth;
            damage = stoneDamage;
            attackCooldown = stoneAttackCooldown;
            swordType = "Stone";
        }
        else
        {
            attackRange = woodAttackRange;
            attackWidth = woodAttackWidth;
            damage = woodDamage;
            attackCooldown = woodAttackCooldown;
        }


        if (!IsBlocking && Mouse.current.leftButton.wasPressedThisFrame && CanAttack())
        {
            isAttacking = true;

            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

            if (mouseScreenPos.x < 0 ||
                mouseScreenPos.x > Screen.width ||
                mouseScreenPos.y < 0 ||
                mouseScreenPos.y > Screen.height)
            {
                return;
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mousePos.z = 0f;

            attackDir = (mousePos - transform.position).normalized;

            animator.SetFloat("DirX", attackDir.x);
            animator.SetFloat("DirY", attackDir.y);

            /*if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }*/

            if (swordType == "Stone")
            {
                animator.SetTrigger("StoneSwordAttack");
                nextAttackTime = Time.time + attackCooldown;
            }
            else
            {
                animator.SetTrigger("WoodSwordAttack");
                nextAttackTime = Time.time + attackCooldown;
            }

            Invoke(nameof(AttackFinished), attackCooldown);
        }
    }

    /*void Attack()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        if (mouseScreenPos.x < 0 ||
            mouseScreenPos.x > Screen.width ||
            mouseScreenPos.y < 0 ||
            mouseScreenPos.y > Screen.height)
        {
            return;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - transform.position).normalized;

        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetTrigger("WoodSwordAttack");

        Vector2 attackCenter = (Vector2)transform.position + direction * (attackRange / 2f);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(
            attackCenter,
            new Vector2(attackRange, attackWidth),
            angle,
            enemyLayer
        );

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(damage);
        }
    }*/

    public void DealAttackDamage()
    {
        if (hasAttackFired) { return; } //Hacky fix to stop unity's animation event from running this twice for some reason
        hasAttackFired = true;

        Debug.Log("Deal damage");

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - transform.position).normalized;

        Vector2 attackCenter =
            (Vector2)transform.position + direction * (attackRange / 2f);

        float angle =
            Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(
            attackCenter,
            new Vector2(attackRange, attackWidth),
            angle,
            enemyLayer
        );

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(damage);
            print(enemy.gameObject.name);
        }
    }

    // Draw attack box in Scene View
    void OnDrawGizmosSelected()
    {
        if (Camera.main == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0f;

        Vector2 direction = (mousePos - transform.position).normalized;

        Vector2 attackCenter = (Vector2)transform.position + direction * (attackRange / 2f);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Gizmos.color = Color.red;

        Matrix4x4 rotationMatrix =
            Matrix4x4.TRS(attackCenter, Quaternion.Euler(0, 0, angle), Vector3.one);

        Gizmos.matrix = rotationMatrix;

        Gizmos.DrawWireCube(Vector3.zero, new Vector3(attackRange, attackWidth, 1));
    }
}
