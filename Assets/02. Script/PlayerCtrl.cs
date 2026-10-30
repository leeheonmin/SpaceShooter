using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] Transform tr = null;
    [SerializeField] public float moveSpeed = 10.0f;
    [SerializeField] public float turnSpeed = 80.0f;
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
        float r = Input.GetAxis("Mouse X");

        // Debug.Log("h = " + h);
        // Debug.Log("V = " + v);

        // transform.position += new Vector3(0, 0, 1);
        
        // transform.position += Vector3.forward * 1;
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);  
        // tr.Translate(Vector3.back * Time.deltaTime * h * moveSpeed); 
        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r); 
    }

    void LateUpdate()
    {
        
    }
    void FixedUpdate()
    {
        
    }
}
