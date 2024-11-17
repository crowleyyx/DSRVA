using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class getSelection : MonoBehaviour
{


    public GameObject[] listOfObjects;



    int iSelectedObject;
    string temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     

    }

    public void selectedButton(int id)
    {
        iSelectedObject = id - 1;


        ObjectPlacement.instance.placedPrefab = listOfObjects[iSelectedObject];

    }



}
