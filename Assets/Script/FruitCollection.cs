using System.Collections.Generic;
using UnityEngine;

class FruitCollection : MonoBehaviour {
    [SerializeField] private GameObject[] fruitPrefabs;
    private readonly List<Fruit> fruits = new List<Fruit>();
    private List<Fruit> dropFruits = new List<Fruit>();
    
    void Awake() {
        foreach (GameObject fruitPrefab in fruitPrefabs) {
            fruits.Add(fruitPrefab.GetComponent<Fruit>());
        }

        for (int i = 0; i < 3; i++) {
            dropFruits.Add(TakeRandomFruit());
        }
    }

    public Fruit GetFirstDropFruit() {
        return dropFruits[0];
    }

    public Fruit GetNextDropFruit() {
       return dropFruits[1];
    }

    public Fruit GetNextLevelFruit(Fruit currentFruit) {
        for (int i = 0; i < fruits.Count; i++) {
            if(FruitTagExtensions.isMaximumLevel(currentFruit.Tag)) return null;
            if (fruits[i].Tag == currentFruit.Tag) {
                return fruits[i + 1];
            }
        }

        return null;
    }

    public void ReleaseFruitList() {
        dropFruits.RemoveAt(0);
        dropFruits.Add(TakeRandomFruit());
    }

    private Fruit TakeRandomFruit() {
        return fruits[Random.Range(0, 4)];
    }
}
