using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class Scores
{
    public string name;
    public int score;
}

public class WebServices : MonoBehaviour
{
    // Start is called before the first frame update
    UnityWebRequest www;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Scores newScore = new Scores
            {
                name = "Stan",
                score = 9
            };

            StartCoroutine(PostRequest("http://localhost:8080/scores", JsonUtility.ToJson(newScore)));
        }
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

}
