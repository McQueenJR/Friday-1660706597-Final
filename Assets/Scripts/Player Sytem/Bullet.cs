using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = (target.position - transform.position).normalized;

        transform.position += dir * speed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < 0.5f)
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        Health hp = target.GetComponent<Health>();

        if (hp != null)
        {
            hp.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}