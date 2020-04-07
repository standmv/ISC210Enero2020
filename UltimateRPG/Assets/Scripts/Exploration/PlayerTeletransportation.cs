using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeletransportation : MonoBehaviour
{
    GameObject _player;
    bool _playerFound = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!_playerFound && GameObject.Find("Player"))
        {
            _playerFound = false;
            _player = GameObject.Find("Player");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Jump"))
        {
            switch (gameObject.name)
            {
                //puerta de espacio abierto
                case "T,35,1":
                    //transportandolo al pequeno cuarto aislado
                    _player.transform.position = new Vector3(32f, -19.5f, _player.transform.position.z);
                    break;
                case "T,32,17":
                    //del pequeno cuarto aislado a la puerta de espacio abierto
                    _player.transform.position = new Vector3(35f, -4.5f, _player.transform.position.z);
                    break;
                case "T,44,1":
                    //del pasillito pequeno a la tienda
                    _player.transform.position = new Vector3(76f, -31.5f, _player.transform.position.z);
                    break;
                case "T,76,29":
                    //de la tienda al pasillito pequeno
                    _player.transform.position = new Vector3(44f, -5.5f, _player.transform.position.z);
                    break;
                case "T,52,5":
                    //del espacio pequeno a la taberna
                    _player.transform.position = new Vector3(30.5f, -31.5f, _player.transform.position.z);
                    break;
                case "T,31,29":
                    //de la puerta derecha de la taberna al espacio pequeno
                    _player.transform.position = new Vector3(52f, -9.5f, _player.transform.position.z);
                    break;
                case "T,30,29":
                    //de la puerta derecha de la taberna al espacio pequeno
                    _player.transform.position = new Vector3(52f, -9.5f, _player.transform.position.z);
                    break;
                default:
                    break;
            }
        }
        else return;
    }
}
