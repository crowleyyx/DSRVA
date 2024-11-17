using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MenuSelector : MonoBehaviour
{
    public Button enterButton;
    public Button exitButton;
    public GameObject Panel;
    



    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        enterButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public void enterMenu()
    {

        enterButton.gameObject.SetActive(false);
        Panel.SetActive(true);
        exitButton.gameObject.SetActive(true);

    }

    public void exitMenu()
    {

        enterButton.gameObject.SetActive(true);
        Panel.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }





}
