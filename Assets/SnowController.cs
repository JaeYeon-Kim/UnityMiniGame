using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{

    GameObject snowGenerator;

    ScoreUpdate scoreUpdate;
    // Start is called before the first frame update
    void Start()
    {
       scoreUpdate = FindObjectOfType<ScoreUpdate>();
       snowGenerator = GameObject.Find("SnowGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {   

        // 충돌 됐는지
        // Debug.Log("충돌 됐니?");

        if(other.name == "Player") {
            Debug.Log("플레이어 충돌");

            // 충돌한 것이 플레이어면 스노우 동작 제거 
            snowGenerator.SetActive(false);

            scoreUpdate.GameOver();
        }
    }
}
