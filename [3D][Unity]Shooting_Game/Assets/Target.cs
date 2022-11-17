using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Target : MonoBehaviour
{
    private ScoreManager scoreManager = null;
    private TargetManager targetManager = null;
    public float targetSpeedX;
    public float targetSpeedY;
    public float targetSpeedZ;
    public float minRange = 5;
    public float maxRange = 20;
    Vector3 targetMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        GameObject smObject = GameObject.Find("ScoreManager");
        targetManager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
        scoreManager = smObject.GetComponent<ScoreManager>();
        targetMoveDirection = new Vector3(targetSpeedX, targetSpeedY, targetSpeedZ);
        targetSpeedX = rand.Next(5);
        targetSpeedY = rand.Next(5);
        targetSpeedZ = rand.Next(5);
    }
    private void OnCollisionEnter(Collision collision)
    {
        scoreManager.OnTargetHit();
        Destroy(gameObject);
        targetManager.TargetNumDecrease();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > maxRange)
            targetMoveDirection.x = -(targetSpeedX);
        if (transform.position.x < minRange)
            targetMoveDirection.x = targetSpeedX;


        if (transform.position.y > maxRange)
            targetMoveDirection.y = -(targetSpeedY);
        if (transform.position.y < minRange)
            targetMoveDirection.y = targetSpeedY;

        if (transform.position.z > maxRange)
            targetMoveDirection.z = -(targetSpeedZ);
        if (transform.position.z < minRange)
            targetMoveDirection.z = targetSpeedZ;

        transform.position += targetMoveDirection * Time.deltaTime;
    }
}
