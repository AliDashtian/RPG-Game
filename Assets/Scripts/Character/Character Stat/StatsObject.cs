using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Character/Stats")]
public class StatsObject : ScriptableObject
{
    public string SavePath;
    public CharacterStats Stats;


    public void UpgradeStat(CharacterStatTypes statType, float amount)
    {
        switch (statType)
        {
            case CharacterStatTypes.Vigor:
                Stats.Vigor = amount;
                break;
            case CharacterStatTypes.Strength:
                Stats.Strength = amount;
                break;
            case CharacterStatTypes.Defense:
                Stats.Defense = amount;
                break;
            case CharacterStatTypes.Endurance:
                Stats.Endurance = amount;
                break;
            case CharacterStatTypes.Faith:
                Stats.Faith = amount;
                break;
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, SavePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Stats);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, SavePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, SavePath), FileMode.Open, FileAccess.Read);
            Stats = (CharacterStats)formatter.Deserialize(stream);
            stream.Close();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Stats = new CharacterStats();
    }
}
