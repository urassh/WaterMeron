using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

class FruitProvider : MonoBehaviour {
    [SerializeField] private GameObject Cloud;
    [SerializeField] private GameObject FruitCollection;
    private FruitCollection fruitCollection;
    private GameObject currentFruitObject;
    private CancellationToken cancellationToken;

    void Start() {
        fruitCollection = FruitCollection.GetComponent<FruitCollection>();
        GenerateFruit();
    }

    void Update() {
        transform.position = new Vector3(Cloud.transform.position.x, Cloud.transform.position.y - 2, transform.position.z);

        if (currentFruitObject == null) return;
        if (currentFruitObject.GetComponent<Rigidbody2D>().isKinematic) {
            currentFruitObject.transform.position = transform.position;
        }
    }

    async void GenerateFruit() {
        while (true) {
            Fruit currentFruit = fruitCollection.GetFirstDropFruit();
            InstantiateFruit(currentFruit);
            fruitCollection.ReleaseFruitList();

            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space), cancellationToken: cancellationToken);

            currentFruitObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            await UniTask.Delay(1000);
        }
    }

    private void InstantiateFruit(Fruit fruit) {
        currentFruitObject = Instantiate(fruit.gameObject, transform.position, Quaternion.identity);
        currentFruitObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
}
