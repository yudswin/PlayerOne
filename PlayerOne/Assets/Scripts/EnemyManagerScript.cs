using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    //Meteor variables
    [Header("Meteor")]
    public GameObject meteor;
    public float spawnRate = 2;
    private float timer = 0;
    public float meteorWidthOffset = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Meteor 
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnMeteor();
            timer = 0;
        }
    }

    //Meteor function
    void SpawnMeteor()
    {
        float randomPoint = Random.Range(-3.8f, 3.6f); 
        Vector3 newPos = new Vector3(randomPoint, transform.position.y, 0);

        Instantiate(meteor, newPos, transform.rotation);
    }
}
