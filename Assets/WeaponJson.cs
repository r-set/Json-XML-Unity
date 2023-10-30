using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WeaponJson : MonoBehaviour
{
    public Weapon weapon;

    [ContextMenu("Save")]
    public void Save()
    {
        string json = SaveToString();
        File.WriteAllText(Application.dataPath + "/weapon.json", json);
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

    [ContextMenu("Load")]
    public void Load()
    {
        string json = File.ReadAllText(Application.dataPath + "/weapon.json");
        weapon = JsonUtility.FromJson<Weapon>(json);

        Debug.Log(weapon.Name);
    }

    [ContextMenu("Delete")]
    public void Delete()
    {
        File.Delete(Application.dataPath + "/weapon.json");
    }

    [System.Serializable]
    public class Weapon
    {
        public string Name;
        public int Damage;
        public float SpeedDamage;
        public float Price;
    }
}
