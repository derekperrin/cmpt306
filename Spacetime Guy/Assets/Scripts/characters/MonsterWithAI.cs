using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWithAI : Monster {
    private Vector3 spawnLocation;
    [SerializeField] private float AI_updateLength;
    private float nextUpdate;
    private bool playerFound;

    private Vector3 currentTarget;
    
    protected override void Start()
    {
        base.Start(); // Call the parent start method.
        spawnLocation = this.gameObject.transform.position; // does this copy a reference or a value?
        currentTarget = spawnLocation;
        nextUpdate = Time.time + AI_updateLength;
        playerFound = false;
    }

	protected override void Movement()
    {
        if (playerToKill == null) return;
        if (playerFound || nextUpdate <= Time.time)
        {
            UpdateTarget();
            nextUpdate = Time.time + AI_updateLength;
        }
        characterRigidBody.velocity = (currentTarget - this.gameObject.transform.position).normalized * this.characterSpeed;
    }
	
    private void UpdateTarget()
    {
        int layerMask = ~((1 << 8) | (1 << 2));   // collide against everything except layer 8 (Enemy) and layer 2 (Ignore Raycast)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (playerToKill.transform.position - transform.position).normalized, Mathf.Infinity, layerMask);
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            currentTarget = playerToKill.transform.position;
            playerFound = true;
        }
        else
        {
            currentTarget = spawnLocation;
            playerFound = false;
        }
    }
}
