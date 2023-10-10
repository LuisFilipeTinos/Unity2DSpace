using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyer : MonoBehaviour
{
    Object playerExplosionRef;

    [SerializeField]
    Animator animFade;
    // Start is called before the first frame update
    void Start()
    {
        playerExplosionRef = Resources.Load("PlayerExplosion");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("DemonEnemy"))
        {
            var spawnerBeetle = GameObject.FindGameObjectWithTag("BeetleSpawner");
            Destroy(spawnerBeetle);

            var spawnerBigEye = GameObject.FindGameObjectWithTag("BigEyeSpawner");
            Destroy(spawnerBigEye);

            var spawnerDemon = GameObject.FindGameObjectWithTag("DemonSpawner");
            Destroy(spawnerDemon);

            var enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (var element in enemies)
                Destroy(element);

            var demonEnemies = GameObject.FindGameObjectsWithTag("DemonEnemy");

            foreach (var element in demonEnemies)
                Destroy(element);

            var explosion = (GameObject)Instantiate(playerExplosionRef);
            explosion.transform.position = this.transform.position;

            animFade.Play("FadeIn");

            Destroy(this.gameObject);
        }
    }
}
