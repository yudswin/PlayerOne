using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;
    bool hashHit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hashHit)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (-4.2f > transform.position.x || transform.position.x > 4.2f || -5.5f > transform.position.y || transform.position.y > 5.5f)
        {

            //Debug.Log("bullet deleted");
            Destroy(gameObject);

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hashHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        Destroy(gameObject);
    }
}
