using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed = 3f;
    public float attackRange = 2f;
    public float damage = 10f;
    public float attackCooldown = 1f;

    public string enemyTag;

    private Rigidbody rb;
    private GameObject target;

    private float attackTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!BattleManager.Instance.battleStarted)
            return;
        
        FindTarget();

        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance > attackRange)
        {
            MoveToTarget();
        }
        else
        {
            Attack();
        }
    }

    void FindTarget()
    {
        if (target != null) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float closest = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);

            if (dist < closest)
            {
                closest = dist;
                target = enemy;
            }
        }
    }

    void MoveToTarget()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;

        rb.linearVelocity = new Vector3(dir.x * speed, rb.linearVelocity.y, dir.z * speed);
    }

    void Attack()
    {
        rb.linearVelocity = Vector3.zero;

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0;

            Health hp = target.GetComponent<Health>();

            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
        }
    }
}
