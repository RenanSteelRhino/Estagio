using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ResourceStoreManager : MonoBehaviour
{

    //Singleton
    public static ResourceStoreManager instance;

    public Button forestryUpgradeButton;

    private void Awake() 
    {
        instance = this;
        forestryUpgradeButton.onClick.AddListener(OnForestryClicked);
    }

    private void OnForestryClicked()
    {
        //Aumenta o nivel
        ResourceNodeLevels.instance.IncreaseNodeLevel(ResourcesTypes.NodeSpecificType.wood);
    }
}
