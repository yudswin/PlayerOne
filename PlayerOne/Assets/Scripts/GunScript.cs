using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public float launchForce;
    public Transform shotPoint;

    public float offSet;

    public SpriteRenderer spriteRender;

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }




    // Update is called once per frame
    void Update()
    {

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offSet);

        if (rotZ < 89 && rotZ > -89)
        {
            // When player facing right
            spriteRender.flipY = false;
        }
        else
        {
            // When player facing left
            spriteRender.flipY = true;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Shoot(); //Shoot when press button 0
        }


    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

    }


}
