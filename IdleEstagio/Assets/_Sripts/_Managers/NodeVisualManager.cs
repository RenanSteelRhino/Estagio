using System.Collections.Generic;
using UnityEngine;

public class NodeVisualManager : MonoBehaviour
{
    public static NodeVisualManager instance;
    private void Awake() 
    {
        instance = this;
    }

    [Header("Levels & Milestones")]
    public int forestryMilestone = 10;
    public int quaryMilestone = 10;
    public int forestryVisualLevel;
    public int quaryVisualLevel;
    [Space][Space][Space][Space]


    [Header("Visual GameObjects Lists")]
    public List<GameObject> forestryVisuals = new List<GameObject>();
    [Space]
    public List<GameObject> quaryVisuals = new List<GameObject>();
    [Space]
    public List<GameObject> huntCabinVisuals = new List<GameObject>();
    [Space]
    public List<GameObject> oreMineVisuals = new List<GameObject>();


    public void UpdateVisual(ResourcesTypes.Types types)
    {
        switch (types)
        {
            case ResourcesTypes.Types.buildingMaterial:

                if(ResourceNodeLevels.instance.currentForestryLevel % forestryMilestone == 0)
                {
                    forestryVisualLevel++;
                    for (int i = 0; i < forestryVisuals.Count; i++)
                        forestryVisuals[i].SetActive(false);

                    if (forestryVisualLevel < forestryVisuals.Count)
                        forestryVisuals[forestryVisualLevel].SetActive(true);
                    else
                        forestryVisuals[forestryVisuals.Count-1].SetActive(true);
                }
                if(ResourceNodeLevels.instance.currentQuaryLevel % quaryMilestone == 0)
                {
                    quaryVisualLevel++;
                    for (int i = 0; i < quaryVisuals.Count; i++)
                        quaryVisuals[i].SetActive(false);

                    if (quaryVisualLevel < quaryVisuals.Count)
                        quaryVisuals[quaryVisualLevel].SetActive(true);
                    else
                        quaryVisuals[quaryVisuals.Count-1].SetActive(true);
                }
            break;

        }
    }
}
