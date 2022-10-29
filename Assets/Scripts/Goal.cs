using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private AudioSource goalSound;
    private bool Enter = false;

    // Start is called before the first frame update
    private void Start()
    {
        goalSound = GetComponent<AudioSource>();

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
                CompleteLevel();
            }
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
