using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using System.Threading;


public class pestle : MonoBehaviour
{
    public Image currentimage;
    public Sprite newSprite1;
    public Sprite newSprite2;
    public Sprite newSprite3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (GlobalVars.grinding == true)
        {
            StartCoroutine(CoUpdate());
            GlobalVars.grinding = false;
            Debug.Log(GlobalVars.grinding);
        }
    }
    


    
    IEnumerator CoUpdate()
    {
        
            
            currentimage.sprite = newSprite2;
            yield return new WaitForSeconds(0.2f);
            currentimage.sprite = newSprite3;
            yield return new WaitForSeconds(0.2f);
            currentimage.sprite = newSprite2;
            yield return new WaitForSeconds(0.2f);
            currentimage.sprite = newSprite1;

        
    }
    
}
