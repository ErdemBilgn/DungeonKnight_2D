using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
   

    public static UIManager Instance 
    { 
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UI Manager is null!!");
            }

            return _instance;           
        }
    }
    void Awake()
    {
        _instance = this;
    }

    [SerializeField] Text playerGemCountText;
    [SerializeField] Image selectionImage;
    [SerializeField] Text gemCountText;
    [SerializeField] Image[] liveImages;
    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = string.Format(gemCount + "G");
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = count.ToString();
    }

    public void UpdateLives(int lives)
    {
        for(int i = 0; i <= lives; i++) 
        {
            if(i == lives)
            {
                liveImages[i].enabled = false;
            }
        }
    }

}
