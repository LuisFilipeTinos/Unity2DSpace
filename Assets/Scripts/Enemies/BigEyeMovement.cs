using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEyeMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    EnemyDie enemyDie;

    bool goingDown;
    bool goingUp;

    Rigidbody2D rb2d;

    float timer;

    private void Start()
    {
        timer = 0;
        goingDown = true;
        enemyDie = GetComponent<EnemyDie>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDie.notTriggeredYet)
        {
            timer += Time.deltaTime;

            if (timer >= 0.2f && goingUp)
            {
                goingDown = true;
                goingUp = false;
                timer = 0;
            }
            else if (timer >= 0.2f && goingDown)
            {
                goingUp = true;
                goingDown = false;
                timer = 0;
            }
        }
        else
        {
            this.transform.position = this.transform.position; //Para o movimento.
            rb2d.velocity = Vector2.zero;
            rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    private void FixedUpdate()
    {
        if (goingDown)
            rb2d.velocity = new Vector2(-speed * Time.deltaTime, -speed * Time.deltaTime);
        else if (goingUp)
            rb2d.velocity = new Vector2(-speed * Time.deltaTime, speed * Time.deltaTime);
    }
}
