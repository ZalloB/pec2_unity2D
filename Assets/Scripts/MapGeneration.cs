using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour{

    public GameObject groundTop, ground, bridge, spikes;

    #region platform paremeters
    [SerializeField]
    private int minSize = 1;
    [SerializeField]
    private int maxSize = 10;

    [SerializeField]
    private int maxHazzardSize = 3;
    [SerializeField]
    private int maxHeight = 3;
    [SerializeField]
    private int maxDrop = -3;

    [SerializeField]
    private int plataforms = 50;
    [SerializeField][Range (0.0f, 1f)]
    private float hazardChange = .5f;
    [SerializeField]
    [Range(0.0f, 1f)]
    private float spikeChange = .1f;
    [SerializeField][Range(0.0f, 1f)]
    private float bridgeChange = .1f;
    #endregion

    private int blockNum = 1;
    private int blockHeight;

    private bool isHazard;

    // Use this for initialization
    void Start()
    {
        //set the begining of the world
        Instantiate(groundTop, new Vector2(0,0), Quaternion.identity);

        //platform generation
        for (int plat = 1; plat < plataforms; plat ++) {

            if (isHazard)
                isHazard = !isHazard;
            else {
                if (Random.value < hazardChange)
                    isHazard = true;
                else
                    isHazard = false;
            }



            if (isHazard) {
                int hazardSize = Mathf.RoundToInt(Random.Range(1, maxHazzardSize));
                if (Random.value < spikeChange)
                {
                    for (int tiles = 0; tiles < hazardSize; tiles++)
                    {
                        Instantiate(spikes, new Vector2(blockNum, blockHeight), Quaternion.identity);
                        for (int i = 1; i <= 5; i++)
                        {
                            Instantiate(ground, new Vector2(blockNum, blockHeight - i), Quaternion.identity);
                        }
                        blockNum++;
                    }
                    continue;
                }
                blockNum += hazardSize;
                continue;
            }

            bool isBridge = Random.value < bridgeChange;

            int platformSize = Mathf.RoundToInt(Random.Range(minSize, maxSize));
            blockHeight = blockHeight + Random.Range(maxDrop, maxHeight);
            for (int tiles = 0; tiles < platformSize; tiles ++){
                if (isBridge)
                {
                    if (tiles == 0 || tiles == platformSize - 1)
                    {
                        Instantiate(groundTop, new Vector2(blockNum, blockHeight), Quaternion.identity);
                        for (int i = 1; i <= 5; i++)
                        {
                            Instantiate(ground, new Vector2(blockNum, blockHeight - i), Quaternion.identity);
                        }
                        blockNum++;
                    }else 
                        Instantiate(bridge, new Vector2(blockNum, blockHeight), Quaternion.identity );
                }
                else
                {
                    Instantiate( groundTop, new Vector2(blockNum, blockHeight), Quaternion.identity );
                    for (int i = 1; i <= 5; i++)
                    {
                        Instantiate(ground, new Vector2(blockNum, blockHeight - i), Quaternion.identity);
                    }
                }
                    
                
                
                blockNum++;
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
