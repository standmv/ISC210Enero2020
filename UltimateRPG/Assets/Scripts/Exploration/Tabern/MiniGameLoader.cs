using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
       
        if (!Input.GetButtonDown("Fire2"))
            return;

        switch (gameObject.name)
        {
            case "Barrel1":
                SceneManager.LoadScene("LittleCannon");
                break;

            case "Barrel2":
                SceneManager.LoadScene("Dejalos_caer");
                break;

            case "Barrel3":
                SceneManager.LoadScene("SampleScene");
                break;

            case "Barrel4":
                SceneManager.LoadScene("UltimateEssence");
                break;

            case "Barrel5":
                SceneManager.LoadScene("FlappyBird");
                break;
        }

    }
}
