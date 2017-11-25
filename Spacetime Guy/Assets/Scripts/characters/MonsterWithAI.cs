using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWithAI : Monster {
    [SerializeField] private float AI_playerSearchDistance;
    private Vector3 spawnLocation;
    [SerializeField] private float AI_updateLength;

    private Vector3 currentTarget;

    protected override void Start()
    {
        base.Start(); // Call the parent start method.
        spawnLocation = this.gameObject.transform.position; // does this copy a reference or a value?
    }

	protected override void Movement()
    {
        UpdateTarget();
        characterRigidBody.velocity = (currentTarget - this.gameObject.transform.position).normalized * this.characterSpeed;
    }
	
    private void UpdateTarget()
    {
        if (Mathf.Max(Mathf.Abs(this.transform.position.x - playerToKill.transform.position.x), Mathf.Abs(this.transform.position.y - playerToKill.transform.position.y)) <= AI_playerSearchDistance)
        {
            currentTarget = playerToKill.transform.position;
        }
        else
        {
            currentTarget = spawnLocation;
        }
    }
}
