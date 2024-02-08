using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatController : MonoBehaviour
{
    [SerializeField]
    bool _beenClicked = false;
    internal static int counter = 0;
    [SerializeField]
    int _viewCounter = counter;
         
    private void OnMouseDown()
    {
        if (_beenClicked == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            _beenClicked = true;
            counter++;
            _viewCounter = counter;
        }
    }


}
