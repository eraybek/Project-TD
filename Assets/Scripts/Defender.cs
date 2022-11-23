using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Defender : MonoBehaviour
{
    
    private Transform target;
    
    [Header("Attributes")]
    public float fireRate = 1f;
    public float range = 4f;
    
    private float fireCountdown = 0f;
        
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    private SpriteRenderer DefenderSR;

    public GameObject arrowPrefab;
    public Transform firePoint;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        DefenderSR = GetComponentInChildren<SpriteRenderer>();
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        if (target.position.x < transform.position.x)
        {
            DefenderSR.flipX = true;
            
        }
        else
        {
            DefenderSR.flipX = false;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject arrowGO = (GameObject)Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Arrow arrow = arrowGO.GetComponent<Arrow>();
        
        if (arrow != null)
        {
            arrow.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
