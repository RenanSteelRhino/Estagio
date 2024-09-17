using TMPro;
using UnityEngine;

public class UIResources : MonoBehaviour
{
    public TextMeshProUGUI resourceText;

    private void Awake() 
    {
        ResourceNode.OnResourceGained += UpdateTextInfo;
    }

    private void UpdateTextInfo(ResourcesTypes.Types type)
    {
        switch (type)
        {
            case ResourcesTypes.Types.madeira:
                break;
        }
        
    }
}
