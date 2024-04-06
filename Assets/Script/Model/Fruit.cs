using Cysharp.Threading.Tasks;
using UnityEngine;

public class Fruit : MonoBehaviour {
    [SerializeField] private FruitTag fruitTag;
    private FruitCollection collection;
    private Score score;

    // このフラグは、衝突判定が連続して呼ばれるのを防ぐためのものです
    private static bool isCollided = false;

    void Start() {
        collection = GameObject.Find("FruitCollection").GetComponent<FruitCollection>();
        score = GameObject.Find("ScoreObject").GetComponent<Score>();
    }

    public FruitTag Tag {
        get {
            return fruitTag;
        }
    }

    async void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Fruit>() == null) return;
        if (collision.gameObject.GetComponent<Fruit>().Tag != fruitTag) return;
        if (collision.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Kinematic) return;
        if (isCollided) return;

        isCollided = true;
        Fruit nextLevelFruit = collection.GetNextLevelFruit(this);

        score.AddScore(fruitTag);
        
        if(nextLevelFruit != null) {
            Instantiate(nextLevelFruit.gameObject, transform.position, Quaternion.identity);
        }

        Destroy(collision.gameObject);
        Destroy(gameObject);

        await UniTask.Delay(100);

        isCollided = false;
    }
}
