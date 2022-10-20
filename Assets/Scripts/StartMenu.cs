using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] AudioSource buttonSound;

    public void StartCraft()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        buttonSound.Play();
    }
    public void StartInstruct()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        buttonSound.Play();
    }
}
