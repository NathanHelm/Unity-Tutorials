using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField]
    private float easingScale = 10;
    [SerializeField]
    private float width = 20; //width of grid
    [SerializeField]
    private float height = 20; //height of grid

    [SerializeField]
    private float gapX = 0; //gap between boxes in grid (horizontal)
    [SerializeField]
    private float gapY = 0; //gap between boxes in grid (vertical)
    [SerializeField]
    private GameObject boxPrefab; //what's this? 
    private Transform spawnSphere; //our spawn sphere object
    private float spacingX,spacingY;







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReferenceExample();
        spacingX = boxPrefab.transform.localScale.x + gapX;
        spacingY = boxPrefab.transform.localScale.y + gapY;
        CreateGridOfBoxes(true);
        //CreateGridOfBoxes(false);

        //offset our parent to be visible in game. 
        spawnSphere.transform.position = new Vector3(-10, -20, 20);

    }
    void ReferenceExample()
    {
        //here our some examples of referencing our object
        //1-get object by type (won't work unless type is unique)
        spawnSphere = FindFirstObjectByType<Transform>();
        //2-will work get object by its tag
        spawnSphere = GameObject.FindGameObjectWithTag("SpawnSphere").GetComponent<Transform>();
        //good practice for large scale games, object is made at runtime
        //spawnSphere = Instantiate(spawnSpherePrefab)

    }
    float PlotXandYPos(int x, int y, bool reflect)
    {
        float xN = x / width;
        float yN = y / height;
        if (reflect)
        {
            yN = 1 - (y / height);
        }
        
        float val = xN * 0.5f + yN * 0.5f;
        Debug.Log($"y:{y} x:{x} sum:{val}");
        return val;
        
    }
    //==ON YOUR OWN==
    //go to https://easings.net and see the various functions that are avaiable
    //can you copy the easing function into your own game???
    //note: the math function is at the bottom of the page of the function you select
    //note: make sure the function's parameter is only x
    //note: you may have to change the easingScale if changes are too drastic or not visible. 

    float ApplyEaseFunction(float x)
    {
        //if 1 end of ease
        //if 0 begin ease
        return x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
    }

    void CreateGridOfBoxes(bool reflection)
    {
        for (int y = 0; y < height; y++)
        {

            for (int x = 0; x < width; x++)
            {
                Transform createdBox = CreateBox(); //here we are getting the position of the transform.
                                                   
                float plot = PlotXandYPos(x, y, reflection); //based on x and y pos, make a range that 0-1.
                float z = ApplyEaseFunction(plot); //apply easing function based on range.

                createdBox.position = new Vector3(spacingX * x, y * spacingY, z * easingScale);  // mutate our position to what we desire!
            }

        }
        
    }
    Transform CreateBox()
    {
       return Instantiate(boxPrefab, spawnSphere.transform).transform;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
