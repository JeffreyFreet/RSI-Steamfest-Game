using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        gameManager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collision");
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<ScoreController>().Score();
            gameManager.gameObject.GetComponent<GameManager>().Spawn();
            Destroy(gameObject);

            if(other.gameObject.GetComponent<AIController>() != null)
                other.gameObject.GetComponent<AIController>().target = null;

        }
    }
}
