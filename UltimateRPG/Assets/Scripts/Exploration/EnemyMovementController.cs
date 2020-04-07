using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    //Vector3 maxWalkSpeed = new Vector3(2f, 2f), maxRunSpeed = new Vector3(5f, 5f);
    Vector3 currentMovementSpeed;
    Vector3 maxEnemyWalkSpeed = new Vector3(3f, 3f);
    //bool isAttacking, isRunning;
    bool lookingRight = true;
    //Animator currentAnimator;
    SpriteRenderer spriteRenderer;
    GameObject _player;
    //const float _ATTACKDISTANCE = 1.5f;
    const float _ENEMYDETECTIONDISTANCE = 8f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //currentAnimator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player"); // For the enemies.
    }

    void Update()
    {
       /* if (Vector3.Distance(_player.transform.position, transform.position) <= _ATTACKDISTANCE)
            isAttacking = true;
        else
            isAttacking = false;
        isRunning = false; // Enemies don't run.
        */
        if (Vector3.Distance(_player.transform.position, transform.position) <= _ENEMYDETECTIONDISTANCE)
        {
            currentMovementSpeed = new Vector3(((_player.transform.position.x < transform.position.x) ? -1 : 1) * maxEnemyWalkSpeed.x,
                ((_player.transform.position.y < transform.position.y) ? -1 : 1) * maxEnemyWalkSpeed.y);
        }
        else
            currentMovementSpeed = Vector3.zero;
        
       // currentAnimator.SetBool("IsAttacking", isAttacking);
       // currentAnimator.SetFloat("Speed", currentMovementSpeed.magnitude);

        if (currentMovementSpeed.x < 0)
            lookingRight = false;
        else if (currentMovementSpeed.x > 0)
            lookingRight = true;

        //gameObject.transform.rotation = new Quaternion(0, lookingRight ? 0 : 180, 0, 0);
        spriteRenderer.flipX = lookingRight ? false : true;

        gameObject.GetComponent<Rigidbody>().velocity = currentMovementSpeed;
    }
}
