using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Singleton;
    public void Awake()
    {
        Singleton = this;
    }

    public InfoScreen infoScreen;

    public void Start()
    {
        infoScreen.gameObject.SetActive(false);
    }

}
