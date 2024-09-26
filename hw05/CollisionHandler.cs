using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

/* 
******************************************************************************************************
    Problem 1: TODO: Finish the case statements for each collectible item listed in CollectibleItems.cs

    Problem 2: TODO: Currently each case statement is written as a string. Enums are especially helpful 
    in preventing spelling mistakes. Instead of using strings sucn as "Enemy" and "Gem", lets use an enum. 
    Please modify each case statement to use an enum instead. 

    Problem 3: TODO: Define a normal tuple and a value tuple. When would you use a value tuple? 
    Print out each value in your defined tuple with Debug.Log

    Problem 4: TODO: Define a new enum within this file taking in different types of particles. 
    Examples include: FireParticles, GoldRibbons, Snowflakes, RainParticles, etc. 

    Problem 5: TODO: 
        * When would you use a tuple over a struct?
            ANSWER:
            I would use a tuple over a struct if I need to return multiple values and not have a data intensive solution.
            It is also a good idea to use tuples when the order of the items actually matters for your solution
        * How do we acces items in a tuple?
            ANSWER:
            tuples use indexing to access the data within. So if I needed to 
            access an the first element of a tuple called Tup, I would type Tup[0].

        * Try visualizing your enum in the Unity Editor. How does it appear as?
            ANSWER:
            The unity editor would show your enum as a dropdown menu.
            You should also be able to choose what values you want to include by selecting and deselecting them.
        
******************************************************************************************************
*/
public class CollisionHandler : MonoBehaviour
{

    public enum Particles{
        FireParticles = 1,
        GoldRibbons = 2,

    }
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ParticleSystem enemyParticles;
    [SerializeField] private CollectibleItems collectibles; 

    (string, int, int) NormTuple = ("Miles", 22, 2001);
    var NormTuple = ("Miles", 22, 2001);

    private void Start(){
        Debug.log($"Name:{NormTuple.Item1}Age:{NormTuple.Item2}Year of Birth:{NormTuple.Item3}");
    }

    private void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case 7:
                Destroy(gameObject);
                break;

            case 3:
                meshRenderer.material = collision.gameObject.GetComponent<Renderer>().material;
                Destroy(collision.gameObject);
                PlayParticles();
                break;
            case 1:
                Destroy(collision.gameObject);
                PlayParticles();
                Player.GetComponent<HealthScript>().health = health - 50;
                break;
            case 2:
                Destroy(collision.gameObject);
                break;
            case 4:
                Debug.log("It is a leaf");
                break;
            case 5:
                Destroy(collision.gameObject);
                Player.GetComponent<Inventory>().additem();
                break;
            case 6:
                Destroy(collision.gameObject);
                Debug.log("It's a fake!!!");
                break;
            case 8:
                Collision.gameObject.GetComponent<HealthScript>().health = health - 50;
                break;


            default:
                break;
        }
    }

    // Check to make sure our value is defined
    private bool IsCollectibleItem(CollectibleItems collectible) {
        return (collectibles & collectible) != 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the tag based on the enum
        gameObject.tag = collectibles.ToString();
    }
}
