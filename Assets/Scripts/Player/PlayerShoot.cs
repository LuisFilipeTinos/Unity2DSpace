using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    Object bulletRef;
    bool canPressSpace; 
    // Start is called before the first frame update
    void Start()
    {
        canPressSpace = true;
        bulletRef = Resources.Load("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canPressSpace)
        {
            canPressSpace = false;
            var bullet = (GameObject)Instantiate(bulletRef);
            bullet.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
            StartCoroutine(ResetTimer());
        }
    }

    private IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(0.4f);
        canPressSpace = true;
    }
}
