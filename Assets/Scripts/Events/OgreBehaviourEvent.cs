using UnityEngine;

public class OgreBehaviourEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BombBehaviourEvent.OnBombExplote += ExploteOgre; // Subscribirse al evento OnBombExplote
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExploteOgre(float range, Vector3 bombPosition)
    {
        if(Vector3.Distance(this.transform.position, bombPosition) < range)
            Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        BombBehaviourEvent.OnBombExplote -= ExploteOgre; // Desuscribirse del evento al destruirse
    }
}
