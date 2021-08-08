using System.Collections;
using UnityEngine;

public class DashCollectible : MonoBehaviour
{
    private GameObject _foreground;
    private GameObject _background;
    private GameObject _obstacle;
    private GameObject _player;
    void Start()
    {
        _foreground = GameObject.Find("foreground");
        _background = GameObject.Find("background");
        _obstacle = GameObject.Find("obstacleBrick");
        _player = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        Destroy(gameObject);
        FindObjectOfType<ObstacleSpawner>().isAdjust = true;
        //StartCoroutine(ObstaclePostionCoroutine());
        //FindObjectOfType<ObstacleSpawner>().obstacleAdjustPosition = 0f;

    }

    IEnumerator ObstaclePostionCoroutine()
    {
        
        yield return new WaitForSeconds(3);       

    }
    

    public void Dash()
    {
       // _foreground.GetComponent<MoveForward>().speed = 10f;
       // _background.GetComponent<BackgroundScroller>().offSet = new Vector2(10f, 0f);
       // _obstacle.GetComponent<MoveForward>().speed = 10f;
       
    }
}
