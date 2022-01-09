using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject[] EnemyPrefab;
    public float respawnTime = 1.0f;

    float minTras;
    float maxTras;

    private float CameraWidth;
    // Start is called before the first frame update
    void Start()
    {
        CameraWidth = ((Camera.main.aspect * 2f * Camera.main.orthographicSize) / 2f);
        StartCoroutine(Wave());
    }

    IEnumerator Wave()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            yield return new WaitForSeconds(respawnTime);
            GameObject gameObject = Instantiate(EnemyPrefab[Random.Range(0, EnemyPrefab.Length)], new Vector2( (CameraWidth +0.1f), (-2.019f)), Quaternion.identity);
        }
    }
}
