using DG.Tweening;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator EnemyAnimator;
    public Transform target;       // Hedef (örneðin oyuncu)
    public float moveSpeed = 7f;   // Hareket hýzý

    void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null)
            return;

        // Hedef yönü
        Vector3 direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > 2f)
        {
            // Hedefe doðru dön ve yürü
            transform.forward = direction;
            transform.position += direction * moveSpeed * Time.deltaTime;

            EnemyAnimator.SetBool("Walk", true);
            EnemyAnimator.SetBool("WalkBack", false);
        }
        else
        {
            // Dur
            EnemyAnimator.SetBool("Walk", false);
            EnemyAnimator.SetBool("WalkBack", false);
        }
    }
}
