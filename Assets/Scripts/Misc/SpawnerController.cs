using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    float limitYInitialValue;

    [SerializeField]
    float limitYFinalValue;

    [SerializeField]
    GameObject enemyPrefab;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (this.gameObject.CompareTag("EnemySpawner") && timer >= 3f)
        {
            var randomYValue = Random.Range(limitYInitialValue, limitYFinalValue);

            //Instanciar o objeto.
            var instantiatedObject = Instantiate(enemyPrefab, new Vector2(this.transform.position.x, randomYValue), Quaternion.identity);

            //Zerar o meu timer.
            timer = 0;
        }
    }
}
