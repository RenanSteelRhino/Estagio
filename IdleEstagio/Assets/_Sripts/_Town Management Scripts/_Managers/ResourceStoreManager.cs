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
            upgradesInStore[i].InitilizeButton();
        }
    }

    public int GetLevelFromType(NodeSpecificType type)
    {
        for (int i = 0; i < upgradesInStore.Count; i++)
        {
            if(type == upgradesInStore[i].type)
                return upgradesInStore[i].level;
        }
        
        return 0;
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
