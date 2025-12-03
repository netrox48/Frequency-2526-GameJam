using DG.Tweening;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    private Animator BossAnimator;
    public Transform target;  // AI'nýn hedefi (örn. oyuncu)
    public float moveSpeed = 7f;

    void Start()
    {
        BossAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null)
            return;

        // Hedefe doðru yönel ve hareket et
        Vector3 direction = (target.position - transform.position).normalized;

        // Basit örnek: sadece ileri veya geri yürüyormuþ gibi animasyonlarý ayarla
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > 2f) // Hedefe belli mesafeden uzaksa yürür
        {
            BossAnimator.SetBool("Walking", true);
            BossAnimator.SetBool("WalkingBack", false);

            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.forward = direction; // Yönünü hedefe çevir
        }
        else
        {
            // Yakýnsa yürümeyi durdur, belki baþka animasyon oynatabilirsin
            BossAnimator.SetBool("Walking", false);
            BossAnimator.SetBool("WalkingBack", false);
        }
    }
}
