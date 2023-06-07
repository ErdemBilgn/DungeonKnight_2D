using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeperEnable : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;
    Player player;
    int itemSelection;
    int currentItemCost;

    void Awake()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            if(player != null) 
            {
                shopPanel.SetActive(true);
                itemSelection = 1;
                currentItemCost = 200;
                UIManager.Instance.UpdateShopSelection(-24);
                UIManager.Instance.OpenShop(player._diamonds);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        //0 = flame sword
        //1 = boots of flight
        //2 = key to castle
        switch(item)
        {
            case 0: // Flame Sword
                UIManager.Instance.UpdateShopSelection(-24);
                currentItemCost = 200;
                break;
            case 1: // Boots
                UIManager.Instance.UpdateShopSelection(-140);
                currentItemCost = 400;
                break;
            case 2: // Keys
                UIManager.Instance.UpdateShopSelection(-242);
                currentItemCost = 100;
                break;
        }
        itemSelection = item;

    }

    public void BuyItem()
    {
        if(player._diamonds >= currentItemCost)
        {
            //award item
            if(itemSelection == 2)
            {
                GameManager.Instance.HasKeyToCaste = true;
            }

            player._diamonds -= currentItemCost;
            UIManager.Instance.OpenShop(player._diamonds);
            Debug.Log("Purchased " + itemSelection);
            Debug.Log("Remaining gems " + player._diamonds);
        }
        else
        {
            Debug.Log("you don enough gems");
            shopPanel.SetActive(false);
        }
    }
}
