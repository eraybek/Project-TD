using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardDefenderPrefab;
    public GameObject anotherDefenderPrefab;

    public GameObject buildEffect;
    
    private DefenderBlueprint defenderToBuild;
    
    public bool CanBuild { get { return defenderToBuild != null; } }
    
    public bool HasMoney { get { return PlayerStats.Money >= defenderToBuild.cost; } }

    
    public void BuildDefenderOn (Node node)
    {
        if (PlayerStats.Money < defenderToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= defenderToBuild.cost;
        
        GameObject defender = (GameObject)Instantiate(defenderToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.defender = defender;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect,5f);
        Debug.Log("Defender build! Money left: " + PlayerStats.Money);
        
    }


    public void SelectDefenderToBuild(DefenderBlueprint defender)
    {
        defenderToBuild = defender;
    }
    
  
}
