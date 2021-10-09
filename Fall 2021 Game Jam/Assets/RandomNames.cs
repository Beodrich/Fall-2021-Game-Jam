using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomNames
{
    public static List<string> names= new List<string>();

    
    public static void MakeNames(){
        names.Add("Dungeonoss");
        names.Add("Little Crab's");
        names.Add("Clawppers");
        names.Add("CRUST-acian");
        names.Add("Papa Crab's");
        names.Add("Hermit Hut");
        names.Add("Scabbo");
        names.Add("Panucci's Pizza");
        names.Add("Pizza Beach");
        names.Add("Shell E.Cheese");
    
    
    }
    public static string GetRandonName(){
        int randomIndex= Random.Range (0, names.Count);
        return names[randomIndex];
    }

}
