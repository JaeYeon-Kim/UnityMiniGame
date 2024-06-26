using UnityEngine;
using UnityEngine.UI;

public class SnowGenerator : MonoBehaviour
{

    [SerializeField]
    private GameObject snowPrefab;
    float span = 1.0f;
    float delta = 0;

    GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        this.score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject snowInstance = Instantiate(snowPrefab);
            int xPosition = Random.Range(-7, 7);
            snowInstance.transform.position = new Vector2(xPosition, 7);
        }
    }
}
