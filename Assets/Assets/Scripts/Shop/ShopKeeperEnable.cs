using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeperEnable : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }
}
