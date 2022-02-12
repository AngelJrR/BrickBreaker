using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    public int numberOfHits = 0;
    public int maxHits;
    public SpriteRenderer brickSprite;
    public GameMaster gameMaster;

    // Start is called before the first frame update
    void Start()
    {
        brickSprite = GetComponent<SpriteRenderer>();
        gameMaster.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        numberOfHits++;
        gameMaster.points++;
        brickSprite.color = Color.red;
        if (numberOfHits < 0)
            brickSprite.color = Color.gray;

        if (numberOfHits >= maxHits)
        {
            Destroy(this.gameObject);
            gameMaster.maxLevelBricks++;
        }
    }
}
