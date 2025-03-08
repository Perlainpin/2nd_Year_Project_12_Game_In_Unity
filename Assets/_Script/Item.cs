using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        public int id;
        public string name;
        public string description;
        public Sprite image;
        public int madnessGiven;
    }
}
