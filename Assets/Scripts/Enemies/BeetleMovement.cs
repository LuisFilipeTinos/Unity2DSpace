using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleMovement : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    float speed;

    EnemyDie enemyDie;

    private void Start()
    {
        enemyDie = GetComponent<EnemyDie>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDie.notTriggeredYet)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
            this.transform.position = this.transform.position; //Para o movimento.
    }
}
