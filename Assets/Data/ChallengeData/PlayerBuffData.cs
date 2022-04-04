using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerBuffData", menuName = "Player Buff", order = 51)]
public class PlayerBuffData : ScriptableObject
{
    [SerializeField]
    private string buffName;
    [SerializeField]
    private string buffTooltip;
    [SerializeField]
    private string playerBuffComponentName;
    [SerializeField]
    private Image buffIcon;

    #region Getters
    public string BuffName
    {
        get
        {
            return buffName;
        }
    }
    public string BuffTooltip
    {
        get
        {
            return buffTooltip;
        }
    }

    public Image BuffIcon
    {
        get
        {
            return buffIcon;
        }
    }

    // For Use with AddComponent<Type>() on Player GO
    public System.Type PlayerBuffComponentType
    {
        get
        {
            System.Type playerBuffType = System.Type.GetType(playerBuffComponentName + ",Assembly-CSharp");
            return playerBuffType;
        }
    }
    /**
        System.Type buffComponentType = challenge.PlayerBuff.PlayerBuffComponentType;
        Player.AddComponent(buffComponentType);
    */
    #endregion
}
