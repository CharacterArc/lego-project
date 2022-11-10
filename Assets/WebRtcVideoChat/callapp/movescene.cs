using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movescene : MonoBehaviour
{
    public string level1;
    public string level2;

    public GameObject child;
    //public GameObject parent;

    Scene yourNexScene;
    public GameObject parentobj;
    public Transform parent;

    




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene(level1, LoadSceneMode.Single);
        }

        if (Input.GetKeyDown("2"))
        {

            // Setting the parent to ‘null’ unparents the GameObject
            // and turns child into a top-level object in the hierarchy
            child.transform.SetParent(null);


            
            //SceneManager.LoadScene(level2);
            SceneManager.LoadScene(level2, LoadSceneMode.Additive);
            //SceneManager.LoadScene(level2, LoadSceneMode.Single);
            //transform.position = new Vector2(0, 50);



            //yourNexScene = SceneManager.GetSceneByName("test");
            yourNexScene = SceneManager.GetSceneAt(1); //scene 4


            SceneManager.MoveGameObjectToScene(child, yourNexScene);

            //parentobj = GameObject.Find("Canvas1s");
            //parent = parentobj.transform;


            //child.transform.SetParent(null);

            // Sets "Parent" as the new parent of the child GameObject.
            //child.transform.SetParent(parent);


            SceneManager.UnloadSceneAsync(0);



        }
        //Application.LoadLevel(level2);
    }
    
}
