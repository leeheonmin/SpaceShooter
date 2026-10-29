using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] Transform tr = null;
    [SerializeField] float moveSpeed = 8.0f;
    [SerializeField] float turnSpeed = 8.0f;
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
        float v = Input.GetAxis("Vertical");

        Debug.Log("h = " + h);
        Debug.Log("V = " + v);

        // transform.position += new Vector3(0, 0, 1);
        
        // transform.position += Vector3.forward * 1;
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir * Time.deltaTime * moveSpeed);  
        // tr.Translate(Vector3.back * Time.deltaTime * h * moveSpeed);   

    }

    void LateUpdate()
    {
        
    }
    void FixedUpdate()
    {
        
    }
}
