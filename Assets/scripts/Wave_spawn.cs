using UnityEngine;
using System.Collections;

public class Wave_spawn : MonoBehaviour {

    public static int waveNumber = 0;
    private float xLimit = 15f;
    private float yLimit = 7.5f;
    private float randomX;
    private float randomY;
    Vector3 spawnPoint = Vector3.zero;
    public Camera cam;
    Vector3 spawnInViewPort;
    private bool canSpawn = false;
    public int maxEnemies = 10;
    private int currentEnemies = 0;
    private int enemiesThisRound = 10;
    private int enemiesTeller;
    public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {

        waveNumber = 1;
        StartCoroutine(spawn(2f));

	}
	
	// Update is called once per frame
	void Update () {

        randomX = Random.Range(-xLimit, xLimit);
        randomY = Random.Range(-yLimit, yLimit);
        

        spawnInViewPort = cam.WorldToViewportPoint(new Vector3(randomX, randomY, 0f));
        

        //print(spawnInViewPort.x + "    " + spawnInViewPort.y + "     " + spawnInViewPort.z);

        if ((spawnInViewPort.x > 1f || spawnInViewPort.x < 0f) && (spawnInViewPort.y > 1f || spawnInViewPort.y < 0f))
        {
            spawnPoint = new Vector3(randomX, randomY, 0f);
            canSpawn = true;
            
        }
        currentEnemies = gameObject.transform.childCount;
        

        if (enemiesTeller == enemiesThisRound && currentEnemies == 0)
        {
            nextWave();
            print(waveNumber);
        }
	}
    void nextWave()
    {
        waveNumber++;
        enemiesTeller = 0;
        enemiesThisRound = 5 * waveNumber + 10;
    }
    IEnumerator spawn(float WaitTime)
    {
        if (canSpawn && currentEnemies < 10 && enemiesThisRound != enemiesTeller)
        {
            GameObject enemyspawning = Instantiate(enemyPrefab, spawnPoint, transform.rotation) as GameObject;
            enemyspawning.transform.parent = gameObject.transform;
            enemiesTeller++;
            canSpawn = false;
        }
        yield return new WaitForSeconds(WaitTime);
        StartCoroutine(spawn(2f));

    }
}
