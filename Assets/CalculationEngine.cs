using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculationEngine : MonoBehaviour {

    public InputField AttackField;
    public InputField DefendField;
    public InputField AttackStopField;

    public Text AttackText;
    public Text DefendText;

    private int attackerSupply;
    private int defenderSupply;
    private int attackStop;

    int[] attackerArray = new int[3];
    int[] defenderArray = new int[2];

    public void Fight()
    {
        attackerSupply = int.Parse(AttackField.text);
        defenderSupply = int.Parse(DefendField.text);
        attackStop = int.Parse(AttackStopField.text);
       
        Simulate(attackerSupply, defenderSupply, attackStop);
    }

    public void Simulate(int aS, int dS, int attStop) 
    {

        
        while ( aS > attStop && dS > 0)
        {
          
        attackerArray[0] = Random.Range(1, 7);
        attackerArray[1] = Random.Range(1, 7);
        attackerArray[2] = Random.Range(1, 7);

        defenderArray[0] = Random.Range(1, 7);
        defenderArray[1] = Random.Range(1, 7);

        //Debug.Log("[" + attackerArray[0] + "]" + " [" + attackerArray[1] + "]" + " [" + attackerArray[2] + "]");
        //Debug.Log("[" + defenderArray[0] + "]" + " [" + defenderArray[1] + "]");

        if (aS >= 3)
        {
            attackerArray = SortArray(attackerArray);
        }

        if (aS < 3 && aS >= 2)
        {
            attackerArray[2] = 0;
            attackerArray = SortArray(attackerArray);
            
        }

        if (aS < 2)
        {
            attackerArray[2] = 0;
            attackerArray[1] = 0;
            attackerArray = SortArray(attackerArray);
            
        }

        if(dS >= 2)
        {
            defenderArray = SortArray(defenderArray);
        }

        if (dS < 2)
        {
            defenderArray[1] = 0;
            defenderArray = SortArray(defenderArray);
        }

            //Debug.Log("[" + attackerArray[0] + "]" + " [" + attackerArray[1] + "]" + " [" + attackerArray[2] + "]");
           // Debug.Log("[" + defenderArray[0] + "]" + " [" + defenderArray[1] + "]");

        for (int i = 0; i < 2; i++)
        {
            if (defenderArray[i] != 0 && attackerArray[i] != 0)
            {
                if (attackerArray[i] > defenderArray[i])
                {
                    dS = dS - 1;
                }
                else
                {
                    aS = aS - 1;
                }
            }
                //Debug.Log("Attacker: " + aS);
               //Debug.Log("Defender: " + dS);
        }

           
        //Debug.Log("[" + attackerArray[0] + "]" + " [" + attackerArray[1] + "]" + " [" + attackerArray[2] + "]");
        //Debug.Log("[" + defenderArray[0] + "]" + " [" + defenderArray[1] + "]");
        }

        Debug.Log("Attacker: " + aS);
        Debug.Log("Defender: " + dS);

        string aSurvived = aS.ToString();
        string dSurvived = dS.ToString();

        AttackText.text = aSurvived;
        DefendText.text = dSurvived;
    }


    public int[] SortArray(int[] arr)
    {
        int[] bridgeArray = new int[1];

        for (int i = 0; i < (arr.Length-1); i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if( arr[i] < arr[j])
                {
                    bridgeArray[0] = arr[j];
                    arr[j] = arr[i];
                    arr[i] = bridgeArray[0];
                }
            }
        }

        return arr;
    }
}
