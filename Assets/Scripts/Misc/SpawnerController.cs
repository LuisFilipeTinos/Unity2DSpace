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
            InstantiateEnemies(beetlePrefab);
        else if (this.gameObject.CompareTag("BigEyeSpawner") && timer >= 3.7f)
            InstantiateEnemies(bigEyePrefab);
        else if (this.gameObject.CompareTag("DemonSpawner") && timer >= 7f)
            InstantiateEnemies(demonPrefab);
    }

    private void InstantiateEnemies(GameObject prefab)
    {
        var randomYValue = Random.Range(limitYInitialValue, limitYFinalValue);

        Instantiate(prefab, new Vector2(this.transform.position.x, randomYValue), Quaternion.identity);

        if (pointManager.GetPoints() > 400)
            StartCoroutine(WaitToInstantiate(prefab));


        if (pointManager.GetPoints() > 1500)
            StartCoroutine(WaitToInstantiate(prefab));

        //Zerar o meu timer.
        timer = 0;
    }

    private IEnumerator WaitToInstantiate(GameObject enemy)
    {
        yield return new WaitForSeconds(.5f);
        var randomYValue = Random.Range(limitYInitialValue, limitYFinalValue);
        Instantiate(enemy, new Vector2(this.transform.position.x, randomYValue), Quaternion.identity);
    }
}
