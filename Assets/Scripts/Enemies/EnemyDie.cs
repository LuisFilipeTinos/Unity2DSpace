using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{

    Animator anim;
    public bool notTriggeredYet;
    Object explosionRef;

    // Start is called before the first frame update
    void Start()
    {
        notTriggeredYet = true;
        anim = GetComponent<Animator>();
        explosionRef = Resources.Load("Explosion");
    }

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && notTriggeredYet)
        {
            notTriggeredYet = false;
            await EnemyDeleted();
        }  
    }

    private async Task EnemyDeleted()
    {
        anim.Play("BeetleDying");
        await Awaitable.WaitForSecondsAsync(0.3f);
        var explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Destroy(this.gameObject);
    }
}
