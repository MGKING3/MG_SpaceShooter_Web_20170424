using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPlayerBullet : MonoBehaviour {
    public GameObject destroyFx;
    public GameObject playerDestroyFx;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }
        Instantiate(destroyFx, transform.position, transform.rotation);
        if (other.CompareTag("Player"))
        {
            Instantiate(playerDestroyFx, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
