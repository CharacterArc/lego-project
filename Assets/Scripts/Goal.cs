using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private AudioSource goalSound;
    private bool Enter = false;
    public GameObject next;
    private GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enter = false;
    }

    private void Update()
    {
        if (Enter)
        {
            if (Input.GetButtonDown("Submit"))
            {
                goalSound.Play();
                CompleteLevel();
            }
        }
    }

    private void CompleteLevel()
    {
        player.transform.position = new Vector2(next.transform.position.x-1, next.transform.position.y+5);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
