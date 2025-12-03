using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BossAI : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 2f;
    public float attackDistance = 2f;
    public float attackCooldown = 1.5f;
    public float damageAmount = 10f;

    private Animator BossAnimator;
    private float lastAttackTime;
    private Rigidbody rb;

    private void Start()
    {
        BossAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Fiziksel dönmeleri engellemek için
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Player.position);

        if (distance > attackDistance)
        {
            // Oyuncuya yönel ve hareket et (fiziksel)
            Vector3 direction = (Player.position - transform.position).normalized;
            Vector3 move = direction * moveSpeed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + move);
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z)); // Yalnýzca yatay bakýþ

            BossAnimator.SetBool("Walking", true);
        }
        else
        {
            BossAnimator.SetBool("Walking", false);

            if (Time.time > lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
                BossAnimator.SetTrigger("Jump");

                HealthSystem healthSystem = Player.GetComponent<HealthSystem>();
                if (healthSystem != null)
                {
                    healthSystem.TakeDamage(damageAmount);
                }
            }
        }
    }
}
