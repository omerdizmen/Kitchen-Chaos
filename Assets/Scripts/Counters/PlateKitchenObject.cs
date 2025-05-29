using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngridentAddedEventArgs> OnIngredientAdded;
    public class OnIngridentAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;
    private List<KitchenObjectSO> kitchenObjectSOs;

    private void Awake()
    {
        kitchenObjectSOs = new List<KitchenObjectSO>();
    }

    public bool TryAddIngridient(KitchenObjectSO kitchenObjectSO)
    {

        if (!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            Debug.Log(kitchenObjectSO.objectName + " invalid objectt");
            return false;
        }


        Debug.Log(kitchenObjectSO + " valid objectt");
        if (kitchenObjectSOs.Contains(kitchenObjectSO))
        {
            Debug.Log("does contain");
            return false;
        }
        else
        {
            Debug.Log("does not contain");
            kitchenObjectSOs.Add(kitchenObjectSO) ;
            
            OnIngredientAdded?.Invoke(this, new OnIngridentAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });
            return true;
        }
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOs;
    }
}
