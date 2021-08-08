using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1f;
    [SerializeField] float spawnAdjustMaxTime = 6f;
    [SerializeField]public float obstacleAdjustPosition = 0f;
    [SerializeField] GameObject obstacle;
    public bool isAdjust = false;
    private float timer = 0;
    private float timerSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMover(3f);
        if (timer>maxTime)
        {
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.position = transform.position + new Vector3(0, 0, 0);
            Destroy(newObstacle, 15);
            timer = 0;
        }
        timer += Time.deltaTime;
        
    }

    public void ObstacleMover(float obstacleAdjustPosition)
    {
        if (isAdjust)
        {
            transform.position += Vector3.right * obstacleAdjustPosition * Time.deltaTime;
            if(timerSpawn > spawnAdjustMaxTime)
            {
                timerSpawn = 0;
                isAdjust = false;
            }
            timerSpawn += Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * 0f * Time.deltaTime;
        }
    }

    IEnumerator WaitToResetSpeed()
    {

        yield return new WaitForSeconds(3);

    }
}
