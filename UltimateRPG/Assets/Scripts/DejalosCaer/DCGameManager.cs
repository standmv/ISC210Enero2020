using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DCGameManager : MonoBehaviour
{
    int Score, Lives = 5;
    public TextMesh LivesText;
    public TextMesh ScoreText;
    bool ScoreSent = false, scoresShowed;
    const float LEFTLIMIT = -9f, RIGHTLIMIT = 9f;
    public GameObject CubePrefab;
    public GameObject TrapPrefab;
    public GameObject LivePrefab;
    GameObject ObjectToInstantiate;
    public GameObject WebScoresText;
    List<Scores> scoresList;
    [Serializable]
    public class Scores
    {
        public string name;
        public int score;
    }

    UnityWebRequest www;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateObject", 0, 1.5f);
        WebScoresText = GameObject.Find("WebScoresText");
        WebScoresText.SetActive(false);
        scoresList = new List<Scores>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Lives <= 0 && !ScoreSent)
        {
            ScoreSent = true;
            Scores newScore = new Scores
            {
                name = "Stanley",
                score = this.Score
            };

            StartCoroutine(PostRequest("http://localhost:8080/scores", JsonUtility.ToJson(newScore)));
        }

        if (ScoreSent && !scoresShowed)
        {
            scoresShowed = true;
            StartCoroutine(GetRequest("http://localhost:8080/scores"));
            WebScoresText.SetActive(true);
        }
    }

    void IncrementCubes()
    {
        Score++;
        ScoreText.text = "Score: " + Score.ToString();
    }

    void DecrementLive(int value)
    {
        Lives += value;
        LivesText.text = "Lives: " + Lives.ToString();
    }

    IEnumerator PostRequest(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        Debug.Log("Response: " + request.downloadHandler.text);
    }

    void InstantiateObject()
    {
        if (Lives <= 0)
            return;

        switch (UnityEngine.Random.Range(0, 10))
        {
            case 0:
                ObjectToInstantiate = CubePrefab;
                break;
            case 1:
                ObjectToInstantiate = TrapPrefab;
                break;
            case 2:
                ObjectToInstantiate = LivePrefab;
                break;
            case 3:
                ObjectToInstantiate = CubePrefab;
                break;
            case 4:
                ObjectToInstantiate = CubePrefab;
                break;
            case 5:
                ObjectToInstantiate = CubePrefab;
                break;
            case 6:
                ObjectToInstantiate = CubePrefab;
                break;
            case 7:
                ObjectToInstantiate = CubePrefab;
                break;
            case 8:
                ObjectToInstantiate = CubePrefab;
                break;
            case 9:
                ObjectToInstantiate = CubePrefab;
                break;

        }
        Instantiate(ObjectToInstantiate, new Vector3(UnityEngine.Random.Range(LEFTLIMIT, RIGHTLIMIT), 6, 0), Quaternion.identity);
    }

    IEnumerator GetRequest(string uri)
    {
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            WebScoresText.gameObject.GetComponent<TextMesh>().text = "Puntaje: /n" + JsonUtility.FromJson<Scores>(webRequest.downloadHandler.text);
            scoresList.AddRange(JsonUtility.FromJson<IEnumerable<Scores>>(webRequest.downloadHandler.text));
            foreach(Scores scr in scoresList)
            {
                Debug.Log("Nombre: " + scr.name + "Puntaje: " + scr.score.ToString());
            }

        }
    }
}
