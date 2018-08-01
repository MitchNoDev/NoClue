using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    [Header("Stats")]
    public int damage;
    public int cost;

    [Header("Game Object References")]
    //public EnemySpawn enemySpawn;
    public GameController GC;
    public BPM BPM;

    public GameObject bulletPrefab;
    public Transform firePoint;

    [SerializeField]
    private GameObject tar = null;
    private float timeForShoot;
    private float timer = 0;

    void Awake()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        BPM = GameObject.FindGameObjectWithTag("GameController").GetComponent<BPM>();
        timeForShoot = BPM.timeForBeat;
    }

	// Update is called once per frame
	void Update ()
    {    
        if (GC.enemies.Count != 0)
        {
            tar = GetClosestEnemy(GC.enemies);
        }

        if (tar != null)
        {
            transform.LookAt(tar.transform);

            if (timeForShoot <= timer)
            {
                Shot(tar);
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }        
	}

    GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    void Shot(GameObject target)
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        
        if (bullet != null)
        {
            bullet.Spawn(target, damage);
        }
    }

}
