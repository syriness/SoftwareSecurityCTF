using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public Transform firePosition;
    public GameObject fireObject;
    public float firePower = 20.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject obj = Instantiate(fireObject);
            obj.transform.position = firePosition.position;

            obj.GetComponent<Rigidbody>().velocity = firePosition.forward * firePower;
        }    
        
    }
}
