using TMPro;
using UnityEngine;

public class UIResources : MonoBehaviour
{

    public TextMeshProUGUI goldText;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI buildingMaterialText;
    public TextMeshProUGUI oreText;

    private void Awake() 
    {
        ResourceNode.OnResourceGained += UpdateTextInfo;
    }

    private void UpdateTextInfo(ResourcesTypes.Types type)
    {
        switch (type)
        {
            case ResourcesTypes.Types.gold:
            Debug.Log("+1 Gold");
            goldText.text = CurrencyManager.Instance.gold.ToString();
                break;
            case ResourcesTypes.Types.food:
                Debug.Log("+1 Food");
                // foodText.text = CurrencyManager.Instance.food.ToString();
                break;
            case ResourcesTypes.Types.buildingMaterial:
                Debug.Log("+1 Building Material");
                // buildingMaterialText.text = CurrencyManager.Instance.buildingMaterial.ToString();
                break;
            case ResourcesTypes.Types.ore:
                Debug.Log("+1 ore");
                oreText.text = CurrencyManager.Instance.ore.ToString();
                break;
            default:
                break;
        }
        
    }
}
