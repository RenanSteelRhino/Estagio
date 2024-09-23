using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ResourceStoreManager : MonoBehaviour
{

    //Singleton
    public static ResourceStoreManager instance;

    public Button forestryUpgradeButton;
    public Button ButtonExit;
    public Button ButtonOpenStore;
    public GameObject Store;


    private void Awake() 
    {
        instance = this;
        forestryUpgradeButton.onClick.AddListener(OnForestryClicked);
        ButtonExit.onClick.AddListener(OnExit);
        ButtonOpenStore.onClick.AddListener(OnOpen);
    }

    private void OnForestryClicked()
    {
        //Aumenta o nivel
        ResourceNodeLevels.instance.IncreaseNodeLevel(ResourcesTypes.NodeSpecificType.wood);
    }
    private void OnExit()
    {
        Store.SetActive(false);
        ButtonOpenStore.gameObject.SetActive(true);
    }
    private void OnOpen()
    {
        Store.SetActive(true);
        ButtonOpenStore.gameObject.SetActive(false);
    }

}
