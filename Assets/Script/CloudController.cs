using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    GameObject cloud;

    Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        cloud = GameObject.Find("cloud");

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = cloud.gameObject.transform.position;
        StartCoroutine(MoveCloud());
    }

    IEnumerator MoveCloud()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("코루틴!!");
    }
}
