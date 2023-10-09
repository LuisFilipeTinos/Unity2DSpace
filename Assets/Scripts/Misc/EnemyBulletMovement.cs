using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    Vector3 playerPos;

    Object explosionRef;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").transform.position;
        explosionRef = Resources.Load("Explosion");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, playerPos, speed * Time.deltaTime);

        if (this.transform.position == playerPos)
        {
            var explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = this.transform.position;
            Destroy(this.gameObject);
        } 
    }
}
