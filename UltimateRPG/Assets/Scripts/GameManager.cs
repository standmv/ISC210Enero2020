using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int Score = 0, Lives = 3;
    public TextMesh ScoreText;
    public TextMesh LivesText;
    public GameObject Collectable;
    int _instantiateCollectable = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_instantiateCollectable == Random.Range(1, 100))
        {
            Instantiate(Collectable, new Vector3(Random.Range(-9.35f, 9.35f), 4.2f, 0), Quaternion.identity);
        }
    }

    void IncrementScore()
    {
        Score++;
        ScoreText.text = "Score: " + Score.ToString();
    }

    void DecrementLive()
    {
        Lives--;
        LivesText.text = "Lives: " + Lives.ToString();
    }
}
