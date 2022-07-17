using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLives : MonoBehaviour
{
    private int currentLives;
    private int maxLives;
    public GameObject lifesPrefab;

    private void Awake()
    {
        var playerObject = FindObjectOfType<Player>();
        currentLives = playerObject.lives;
        maxLives = playerObject.maxLives;
        for (int lvs = 1; lvs <= maxLives; lvs++)
        {
            //.Log("Lives: " + lvs.ToString());
            GameObject lifeIcon = Instantiate(lifesPrefab, this.transform);
            lifeIcon.transform.position += new Vector3((float)((lvs - 1)/2.0) , 0, 0);
            if (lvs > currentLives)
            {
                lifeIcon.GetComponent<Image>().color = Color.black;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
