using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDagger : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        DestroyTimer(timer);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit!");
            Destroy(this.gameObject);
        }


    }

    private void DestroyTimer(float _timer)
    {
        Destroy(this.gameObject, _timer);

    }

}
