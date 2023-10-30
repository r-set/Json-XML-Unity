using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

public class WeaponXML : MonoBehaviour
{
    public Weapon weapon;

    [ContextMenu("Save")]
    public void Save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Weapon));
        TextWriter writer = new StreamWriter(Application.dataPath + "/weapon.xml");
        serializer.Serialize(writer, weapon);
        writer.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Weapon));
        TextReader reader = new StreamReader(Application.dataPath + "/weapon.xml");
        weapon = serializer.Deserialize(reader) as Weapon;
        reader.Close();
    }

    [ContextMenu("Delete")]
    public void Delete()
    {
        File.Delete(Application.dataPath + "/weapon.xml");
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
