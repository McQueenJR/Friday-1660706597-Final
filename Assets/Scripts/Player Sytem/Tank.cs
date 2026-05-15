using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tank : MonoBehaviour
{
    [Header("Target")]
    public string enemyTag;

    [Header("Movement")]
    public float moveSpeed = 2f;

    [Header("Attack")]
    public float attackRange = 2f;
    public float damage = 15f;
    public float attackCooldown = 1.5f;

    private Rigidbody rb;
    private GameObject target;

    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!BattleManager.Instance.battleStarted)
            return;
        
        FindTarget();

        if (target == null)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        float distance = Vector3.Distance(
            transform.position,
            target.transform.position
        );
        
        Vector3 lookPos =
            target.transform.position - transform.position;

        lookPos.y = 0;

        if (lookPos != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookPos);
        }
        
        if (distance > attackRange)
        {
            MoveToTarget();
        }
        else
        {
            StopMoving();
            Attack();
        }
    }

    void FindTarget()
    {
        GameObject[] enemies =
            GameObject.FindGameObjectsWithTag(enemyTag);

        float closest = Mathf.Infinity;

        target = null;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(
                transform.position,
                enemy.transform.position
            );

            if (dist < closest)
            {
                closest = dist;
                target = enemy;
            }
        }
    }

    void MoveToTarget()
    {
        Vector3 dir =
            (target.transform.position - transform.position).normalized;

        rb.linearVelocity = new Vector3(
            dir.x * moveSpeed,
            rb.linearVelocity.y,
            dir.z * moveSpeed
        );
    }

    void StopMoving()
    {
        rb.linearVelocity = Vector3.zero;
    }

    void Attack()
    {
        timer += Time.deltaTime;

        if (timer >= attackCooldown)
        {
            timer = 0;

            Health hp = target.GetComponent<Health>();

            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
        }
    }
}