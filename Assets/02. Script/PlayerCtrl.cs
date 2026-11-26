using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class PlayerCtrl : MonoBehaviour
{   
    const float FADE_LENGTH = 0.25f;
    const float CONPARE_FLOAT = 0.1f;
    [SerializeField] Transform tr = null;
    [SerializeField] private Animation anim;

    [SerializeField] public float moveSpeed = 10.0f;
    [SerializeField] public float turnSpeed = 80.0f;

    private readonly float initHp = 100.0f;
    public float currHp;
    void Awake()
    {
        
    }
    void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

        anim.Play("Idle");

        turnSpeed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        turnSpeed = 80.0f;
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

        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        if (v >= CONPARE_FLOAT) 
        {
            anim.CrossFade("RunF", FADE_LENGTH);
        }
        else if (v <= -CONPARE_FLOAT)
        {
            anim.CrossFade("RunB", FADE_LENGTH); 
        } 
        else if (h >= CONPARE_FLOAT)
        {
            anim.CrossFade("RunR", FADE_LENGTH);
        }
        else if (h <= -CONPARE_FLOAT)
        {
            anim.CrossFade("RunL", FADE_LENGTH);
        }
        else
        {
            anim.CrossFade("Idle", FADE_LENGTH);
        }
    }
    void OnTriggerEnter(Collider coll)
    {  
        if (currHp >= 0.0f && coll.CompareTag("PUNCH"))
        {
            currHp -= 10.0f;
            Debug.Log($"Player hp = {currHp/initHp}");

            if (currHp <= 0.0f)
            {
                PlayerDie();
            }
        }
    }

    void PlayerDie()
    {
        Debug.Log("Player Die!");
    }
}
