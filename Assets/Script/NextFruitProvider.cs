using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

class NextFruitProvider : MonoBehaviour
{
    [SerializeField] private GameObject fruitCollectionObject;

    private FruitCollection fruitCollection;
    private GameObject nextFruitObject;
    private CancellationToken cancellationToken;

    void Start()
    {
        fruitCollection = fruitCollectionObject.GetComponent<FruitCollection>();
        TakeNextFruit();
    }

    async void TakeNextFruit()
    {
        while (true)
        {
            Fruit nextFruit = fruitCollection.GetNextDropFruit();
            InstantiateNextFruit(nextFruit);
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space), cancellationToken: cancellationToken);
            await UniTask.Delay(1000);
            Destroy(nextFruitObject);
        }
    }

    private void InstantiateNextFruit(Fruit fruit) {
        nextFruitObject = Instantiate(fruit.gameObject, transform.position, Quaternion.identity);
        nextFruitObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
}
