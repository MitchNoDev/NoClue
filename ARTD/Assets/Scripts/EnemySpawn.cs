using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [Header("Object References")]
    public GameObject enemySpawner;
    public GameController GC;
    public BPM BPM;

    [Header("Waves Lists")]
    public List<GameObject> waveOne;
    public List<GameObject> waveTwo;
    public List<GameObject> waveThree;

    private int count = 0;
    public bool waveStarted = false;
    public int waveNumber;

    private float timeForSpawn;
    private float timer = 0;

    private void Start()
    {
        GC = GetComponent<GameController>();
        BPM = GetComponent<BPM>();        
        count = 0;
    }

    void Update()
    {        
        if (waveStarted)
        {            
            StartWave();
        }
    }

    void StartWave()
    {        
        //Case system for waves
        switch (waveNumber)
        {            
            //first wave
            case 0:
                timeForSpawn = BPM.timeForBeat;
                SpawnEnemy(waveOne);
                break;
            //Second wave
            case 1:
                timeForSpawn = BPM.timeForBeat;
                SpawnEnemy(waveTwo);
                break;
           //Thirs wave
            case 2:
                timeForSpawn = BPM.timeForBeat;
                SpawnEnemy(waveThree);
                break;
        }               
    }

    void SpawnEnemy(List<GameObject> currentWave)
    {
        GameObject temp;
        while (count != currentWave.Count)
        {
            if (timeForSpawn <= timer)
            {               
                temp = Instantiate(currentWave[count], enemySpawner.transform.position, Quaternion.Euler(0, 0, 0), enemySpawner.transform);
                GC.enemies.Add(temp);
                timer = 0;
                print(timer);
                count ++;                
            }
            else
            {
                print("fuck");
                timer += Time.deltaTime;
                print(timer);
            }
        }

        waveStarted = false;
        count = 0;
        ++waveNumber;
    }
}
