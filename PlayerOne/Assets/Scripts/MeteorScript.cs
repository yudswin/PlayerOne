using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public float fieldofImpact;
    public float force;

    public LayerMask LayerToHit;

    //Explode Animation
    public Animator animator;

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MeteorExplode();
        animator.Play("explode");
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }

    void MeteorExplode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }



}
