using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    public int targetMax = 5;
    public int waitingTime = 3;
    private int targetNum = 0;
    private float timer;
    public GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 5;
    }

    public void TargetNumDecrease()
    {
        targetNum -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (targetNum < targetMax)
        {
            if (timer > waitingTime)
            {
                timer = 0;
                GameObject obj = Instantiate(target);
                targetNum += 1;
            }
        }
    }
}
