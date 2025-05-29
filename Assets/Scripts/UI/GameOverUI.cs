using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliveredText;

    private void Start()
    {
        KitchenGameManager.Instance.onStateChanged += KitchenGameManager_onStateChanged;
    }

    private void KitchenGameManager_onStateChanged(object sender, System.EventArgs e)
    {

        if (KitchenGameManager.Instance.IsGameOver())
        {
            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessRecipesAmount().ToString();
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    
}
