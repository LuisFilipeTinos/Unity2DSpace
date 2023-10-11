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
    GameObject beetlePrefab;

    [SerializeField]
    GameObject bigEyePrefab;

    [SerializeField]
    GameObject demonPrefab;

    float timer;

    PointManager pointManager;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        pointManager = GameObject.Find("PointsManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (this.gameObject.CompareTag("BeetleSpawner") && timer >= 3f)
        {
            var randomYValue = Random.Range(limitYInitialValue, limitYFinalValue);

            //Instanciar o objeto.
            Instantiate(beetlePrefab, new Vector2(this.transform.position.x, randomYValue), Quaternion.identity);

            if (pointManager.GetPoints() > 400)
                StartCoroutine(WaitToInstantiate(beetlePrefab));
                

            if (pointManager.GetPoints() > 1500)
                StartCoroutine(WaitToInstantiate(beetlePrefab));

            //Zerar o meu timer.
            timer = 0;
        }
        else if (this.gameObject.CompareTag("BigEyeSpawner") && timer >= 3.7f)
        {
            var randomYValue = Random.Range(limitYInitialValue, limitYFinalValue);

            //Instanciar o objeto.
            Instantiate(bigEyePrefab, new Vector2(this.transform.position.x, randomYValue), Quaternion.identity);

            if (pointManager.GetPoints() > 400)
                StartCoroutine(WaitToInstantiate(bigEyePrefab));


            if (pointManager.GetPoints() > 1500)
                StartCoroutine(WaitToInstantiate(bigEyePrefab));

            //Zerar o meu timer.
            timer = 0;
        }
        else if (this.gameObject.CompareTag("DemonSpawner") && timer >= 7f)
        {
            var randomYValue = Random.Range(limitYInitialValue, limitYFinalValue);

            //Instanciar o objeto.
            Instantiate(demonPrefab, new Vector2(this.transform.position.x, randomYValue), Quaternion.identity);

            if (pointManager.GetPoints() > 400)
                StartCoroutine(WaitToInstantiate(demonPrefab));


            if (pointManager.GetPoints() > 1500)
                StartCoroutine(WaitToInstantiate(demonPrefab));

            //Zerar o meu timer.
            timer = 0;
        }
    }

    private IEnumerator WaitToInstantiate(GameObject enemy)
    {
        yield return new WaitForSeconds(.5f);
        var randomYValue = Random.Range(limitYInitialValue, limitYFinalValue);
        Instantiate(enemy, new Vector2(this.transform.position.x, randomYValue), Quaternion.identity);
    }
}
