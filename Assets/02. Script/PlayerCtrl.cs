using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Transform tr;
    void Awake()
    {
        
    }
    void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v =Input.GetAxis("Vertical");

        Debug.Log("h = " + h);
        Debug.Log("V = " + v);

        // transform.position += new Vector3(0, 0, 1);
        
        transform.position += Vector3.forward * 1;
    }

    void LateUpdate()
    {
        
    }
    void FixedUpdate()
    {
        
    }
}
