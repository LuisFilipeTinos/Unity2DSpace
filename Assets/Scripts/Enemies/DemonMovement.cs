using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    EnemyDie enemyDie;

    Rigidbody2D rb2d;

    float timer;

    Object enemyBulletRef;

    private void Start()
    {
        enemyDie = GetComponent<EnemyDie>();
        rb2d = GetComponent<Rigidbody2D>();
        timer = 0;
        enemyBulletRef = Resources.Load("EnemyBullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDie.notTriggeredYet)
            rb2d.velocity = new Vector2(-speed * Time.deltaTime, rb2d.velocity.y);
        else
        {
            this.transform.position = this.transform.position; //Para o movimento.
            rb2d.velocity = Vector2.zero;
            rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        timer += Time.deltaTime;

        if (timer > 3)
        {
            var enemyBullet = (GameObject)Instantiate(enemyBulletRef);
            enemyBullet.transform.position = this.transform.position;
            timer = 0;
        }
    }
}
