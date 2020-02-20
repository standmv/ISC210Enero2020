using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCDeadzoneController : MonoBehaviour
{
    DCGameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GlobalScripts").GetComponent<DCGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
            gameManager.SendMessage("IncrementCubes");
        Destroy(other.gameObject);
       
    }
}
