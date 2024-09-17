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
                break;
            case ResourcesTypes.Types.food:
                Debug.Log("+1 Food");
                break;
            case ResourcesTypes.Types.buildingMaterial:
                Debug.Log("+1 Building Material");
                break;
            case ResourcesTypes.Types.ore:
                Debug.Log("+1 ore");
                break;
            default:
                break;
        }
        
    }
}
