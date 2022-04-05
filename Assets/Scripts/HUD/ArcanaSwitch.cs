using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcanaSwitch : MonoBehaviour
{
    public Image[] cards;
    public int counter = 0;
    public GameObject arcanaMenu;
    public bool arcanaSwitch;

    // Start is called before the first frame update
    void Start()
    {
        arcanaMenu.SetActive(false);
        cards[0].enabled = false;
        cards[1].enabled = false;
        cards[2].enabled = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if(arcanaSwitch){
            arcanaMenu.SetActive(true);
            cards[counter].enabled = true;
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
            arcanaMenu.SetActive(false);
            cards[counter].enabled = false;
        }
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        arcanaSwitch = false;
        arcanaMenu.SetActive(false);
        counter += 1;
    }
}
