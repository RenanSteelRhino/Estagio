using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResourceStoreManager : MonoBehaviour
{

    //Singleton
    public static ResourceStoreManager instance;

    [Header("=== UI ===")]
    public Button ButtonExit;
    public Button ButtonOpenStore;
    public GameObject Store;
    [Space]
    [Header("=== Upgrades ===")]

    public List<StoreUpgrade> upgradesInStore = new List<StoreUpgrade>();

    private void Awake() 
    {
        instance = this;

        ButtonExit?.onClick.AddListener(OnExit);
        ButtonOpenStore?.onClick.AddListener(OnOpen);

        //Initialization of store ui stuff
        for (int i = 0; i < upgradesInStore.Count; i++)
        {
            upgradesInStore[i].UpdateUI();
            InitializeButton(upgradesInStore[i].uiInfo.ReturnBuyButton(), upgradesInStore[i].basedOnType);
        }
    }

    private void InitializeButton(Button btn, NodeSpecificType type)
    {
        switch(type)
        {
            case NodeSpecificType.wood:
                btn.onClick.AddListener(OnForestryClicked);
            break;
            
            case NodeSpecificType.stone:   
                btn.onClick.AddListener(OnQuarryClicked);
            break;

        }
    }

    private void OnForestryClicked()
    {
        //Aumenta o nivel
        // ResourceNodeLevels.instance.IncreaseNodeLevel(ResourcesTypes.NodeSpecificType.wood);
        upgradesInStore.Where(item => item.newName == "Forestry").LastOrDefault().LevelUP();
    }
    private void OnQuarryClicked()
    {
        upgradesInStore.Where(item => item.newName == "Quarry").LastOrDefault().LevelUP();

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
