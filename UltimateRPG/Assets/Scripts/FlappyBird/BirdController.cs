using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    
    Vector3 _clickForce;
    Rigidbody BirdRefence;
    bool _gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        _clickForce = new Vector3(0, 200, 0);
        BirdRefence = gameObject.GetComponent<Rigidbody>();
        BirdRefence.velocity = Vector3.zero;
        //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void FixedUpdate()
    {
        if (_gameStarted)
        {
            gameObject.transform.Translate(BirdRefence.velocity * Time.deltaTime + Physics.gravity * Mathf.Pow(Time.deltaTime, 2) / 2);
            BirdRefence.velocity += Physics.gravity * Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _gameStarted = true;
            BirdRefence.velocity = Vector3.zero;
            BirdRefence.AddForce(_clickForce);
        }
    }
}
