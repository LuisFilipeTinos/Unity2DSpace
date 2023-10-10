using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{

    Animator anim;
    public bool notTriggeredYet;
    Object explosionRef;
    float enemyDemonLife;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        enemyDemonLife = 3;
        notTriggeredYet = true;
        anim = GetComponent<Animator>();
        explosionRef = Resources.Load("Explosion");
        sr = GetComponent<SpriteRenderer>();
    }

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && notTriggeredYet)
        {
            if (this.gameObject.CompareTag("DemonEnemy") && enemyDemonLife > 0)
            {
                enemyDemonLife--;
                await EnemyTakeDamage();
            }
            else
            {
                notTriggeredYet = false;
                await EnemyDeleted();
            }
        }
    }

    private async Task EnemyDeleted()
    {
        anim.Play("BeetleDying");
        GameObject.Find("PointsManager").GetComponent<PointManager>().AddPoints(); // Adiciona pontos na UI
        await Awaitable.WaitForSecondsAsync(0.3f);
        var explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Destroy(this.gameObject);
    }

    private async Task EnemyTakeDamage()
    {
        sr.color = Color.clear;
        await Awaitable.WaitForSecondsAsync(0.06f);
        sr.color = Color.white;
        await Awaitable.WaitForSecondsAsync(0.06f);
        sr.color = Color.clear;
        await Awaitable.WaitForSecondsAsync(0.06f);
        sr.color = Color.white;
        await Awaitable.WaitForSecondsAsync(0.06f);
        sr.color = Color.clear;
        await Awaitable.WaitForSecondsAsync(0.06f);
        sr.color = Color.white;
        await Awaitable.WaitForSecondsAsync(0.06f);
        sr.color = Color.clear;
        await Awaitable.WaitForSecondsAsync(0.06f);
        sr.color = Color.white;
        await Awaitable.WaitForSecondsAsync(0.06f);
    }
}
