using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public float launchForce;
    public Transform shotPoint;




    // Update is called once per frame
    void Update()
    {
        Vector2 gunPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - gunPos;
        transform.position = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }


    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

    }


}
