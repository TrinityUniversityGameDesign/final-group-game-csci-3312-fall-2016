﻿using UnityEngine;
using System.Collections;
using System;

public class TerrainGenerator : MonoBehaviour {

    public int width;
    public int height;
    public int depth;
    public double randomnessThreshold;
    public GameObject zero;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject W;
    public GameObject N;
    public GameObject E;
    public GameObject S;
    public GameObject WN;
    public GameObject WE;
    public GameObject WS;
    public GameObject NE;
    public GameObject NS;
    public GameObject ES;
    public GameObject WNE;
    public GameObject WNS;
    public GameObject WES;
    public GameObject NES;
    public GameObject WNES;

    //private ArrayList board;
    private int[,] board;

    void Awake() {
        board = new int[width,height];
        createTerrain();
        /*for(int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                Debug.Log(board[i, j]);
            }
        }*/
    }

    void Start()
    {
        addTerrainToScene();
    }

    void createTerrain() {
        createNewBoard();
        //int y = UnityEngine.Random.Range(0,(int)(height * 0.6) + (int)(height * 0.2));
        //int x = UnityEngine.Random.Range(0, (int)(width * 0.6) + (int)(width * 0.2));
        board[width/2,height/2] = 1;
        for (int i = 0; i < depth; i++) board = fillTerrain((int[,])board.Clone());
        checkForEdges();
        checkForBoundaries();
    }

    public void doEverything()
    {
        //Destroy((GameObject)board);
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        board = new int[width, height];
        createTerrain();
        addTerrainToScene();
    }

    void createNewBoard() {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                board[i, j] = 0;
            }
        }
    }

    int[,] fillTerrain(int[,] b)
    {
        for(int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                if(board[i,j]==1)
                {
                    if ((i - 1) > -1 && (j - 1) > -1 && UnityEngine.Random.value <= randomnessThreshold) b[i - 1, j - 1] = 1;
                    if ((i - 1) > -1 && UnityEngine.Random.value <= randomnessThreshold) b[i - 1, j] = 1;
                    if ((i - 1) > -1 && (j + 1) < height && UnityEngine.Random.value <= randomnessThreshold) b[i - 1, j + 1] = 1;
                    if ((j - 1) > -1 && UnityEngine.Random.value <= randomnessThreshold) b[i, j - 1] = 1;
                    if ((j + 1) < height && UnityEngine.Random.value <= randomnessThreshold) b[i, j + 1] = 1;
                    if ((i + 1) < width && (j - 1) > -1 && UnityEngine.Random.value <= randomnessThreshold) b[i + 1, j - 1] = 1;
                    if ((i + 1) < width && UnityEngine.Random.value <= randomnessThreshold) b[i + 1, j] = 1;
                    if ((i + 1) < width && (j + 1) < height && UnityEngine.Random.value <= randomnessThreshold) b[i + 1, j + 1] = 1;
                }
            }
        }
        return b;
    }

    void checkForEdges()
    {
        for(int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                bool res = false;
                if(board[i,j]==1)
                {
                    if ((i - 1) > -1 && board[i - 1, j] == 0) res = true;
                    if ((j - 1) > -1 && board[i, j - 1] == 0) res = true;
                    if ((j + 1) < height && board[i, j + 1] == 0) res = true;
                    if ((i + 1) < width && board[i + 1, j] == 0) res = true;
                    if ((i == 0)) res = true;
                    else if ((i == (width - 1))) res = true;
                }
                if (res == true) board[i, j] = 2;
            }
        }
    }

    void checkForBoundaries()
    {
        for(int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                if((board[i,j]==1 || board[i,j]==2) && ((i==0 || i==(width-1)) || (j==0 || j==(height-1)))) { board[i, j] = 3; }
            }
        }
    }

    void addTerrainToScene()
    {
        for(int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                if (board[i, j] == 2) createEdgeSprite(i, j);
                if (board[i, j] == 1) createTerrainSprite(i, j);
                if (board[i, j] == 3)
                {
                    createBoundarySprite(i, j);
                    //Debug.Log("calling createBoundarySprite(" + i + "," + j + ")");
                }
            }
        }
    }

    void createEdgeSprite(int i, int j)
    {
        GameObject image = one;
        try
        {
                if (board[i - 1, j] == 0 && board[i, j - 1] != 0 && board[i + 1, j] != 0 && board[i, j + 1] != 0) image = W;
                else if (board[i - 1, j] != 0 && board[i, j - 1] == 0 && board[i + 1, j] != 0 && board[i, j + 1] != 0) image = S;
                else if (board[i - 1, j] != 0 && board[i, j - 1] != 0 && board[i + 1, j] == 0 && board[i, j + 1] != 0) image = E;
                else if (board[i - 1, j] != 0 && board[i, j - 1] != 0 && board[i + 1, j] != 0 && board[i, j + 1] == 0) image = N;
                else if (board[i - 1, j] == 0 && board[i, j - 1] == 0 && board[i + 1, j] != 0 && board[i, j + 1] != 0) image = WS;
                else if (board[i - 1, j] == 0 && board[i, j - 1] != 0 && board[i + 1, j] == 0 && board[i, j + 1] != 0) image = WE;
                else if (board[i - 1, j] == 0 && board[i, j - 1] != 0 && board[i + 1, j] != 0 && board[i, j + 1] == 0) image = WN;
                else if (board[i - 1, j] != 0 && board[i, j - 1] == 0 && board[i + 1, j] == 0 && board[i, j + 1] != 0) image = ES;
                else if (board[i - 1, j] != 0 && board[i, j - 1] == 0 && board[i + 1, j] != 0 && board[i, j + 1] == 0) image = NS;
                else if (board[i - 1, j] != 0 && board[i, j - 1] != 0 && board[i + 1, j] == 0 && board[i, j + 1] == 0) image = NE;
                else if (board[i - 1, j] == 0 && board[i, j - 1] == 0 && board[i + 1, j] == 0 && board[i, j + 1] != 0) image = WES;
                else if (board[i - 1, j] == 0 && board[i, j - 1] == 0 && board[i + 1, j] != 0 && board[i, j + 1] == 0) image = WNS;
                else if (board[i - 1, j] == 0 && board[i, j - 1] != 0 && board[i + 1, j] == 0 && board[i, j + 1] == 0) image = WNE;
                else if (board[i - 1, j] != 0 && board[i, j - 1] == 0 && board[i + 1, j] == 0 && board[i, j + 1] == 0) image = NES;
                else if (board[i - 1, j] == 0 && board[i, j - 1] == 0 && board[i + 1, j] == 0 && board[i, j + 1] == 0) image = WNES;
        }
        catch (Exception e)
        {

        }

        float x = Math.Abs((width / 2) - i) * 0.74f;
        if (i < (width / 2)) x *= (-1);
        float y = Math.Abs((height / 2) - j) * 0.74f;
        if (j < (height / 2)) y *= (-1);

        GameObject tmpTerrain = Instantiate(image, new Vector3(x, y, this.transform.localPosition.z), Quaternion.identity) as GameObject;
        tmpTerrain.transform.parent = gameObject.transform;
    }

    void createBoundarySprite(int i, int j)
    {
        GameObject image = one;
        try
        {
            //Debug.Log(j);
            if(j==0)
            {
                //Debug.Log("check");
                if (board[i - 1, j] == 0 && board[i + 1, j] == 0 && board[i, j + 1] == 0) image = WNES;
                else if (board[i - 1, j] == 0 && board[i + 1, j] == 0 && board[i, j + 1] != 0) image = WES;
                else if (board[i - 1, j] == 0 && board[i + 1, j] != 0 && board[i, j + 1] == 0) image = WNS;
                else if (board[i - 1, j] != 0 && board[i + 1, j] == 0 && board[i, j + 1] == 0) image = NES;
                else if (board[i - 1, j] != 0 && board[i + 1, j] == 0 && board[i, j + 1] != 0) image = ES;
                else if (board[i - 1, j] == 0 && board[i + 1, j] != 0 && board[i, j + 1] != 0) image = WS;
                else if (board[i - 1, j] != 0 && board[i + 1, j] != 0 && board[i, j + 1] == 0) image = NS;
                else image = S;
                //Debug.Log(image);
            } else if (j==(height-1))
            {
                if (board[i - 1, j] == 0 && board[i + 1, j] == 0 && board[i, j - 1] == 0) image = WNES;
                else if (board[i - 1, j] == 0 && board[i + 1, j] == 0 && board[i, j - 1] != 0) image = WNE;
                else if (board[i - 1, j] == 0 && board[i + 1, j] != 0 && board[i, j - 1] == 0) image = WNS;
                else if (board[i - 1, j] != 0 && board[i + 1, j] == 0 && board[i, j - 1] == 0) image = NES;
                else if (board[i - 1, j] != 0 && board[i + 1, j] == 0 && board[i, j - 1] != 0) image = NE;
                else if (board[i - 1, j] == 0 && board[i + 1, j] != 0 && board[i, j - 1] != 0) image = WN;
                else if (board[i - 1, j] != 0 && board[i + 1, j] != 0 && board[i, j - 1] == 0) image = NS;
                else image = N;
            }
        }
        catch (Exception e)
        {

        }

        float x = Math.Abs((width / 2) - i) * 0.74f;
        if (i < (width / 2)) x *= (-1);
        float y = Math.Abs((height / 2) - j) * 0.74f;
        if (j < (height / 2)) y *= (-1);

        GameObject tmpTerrain = Instantiate(image, new Vector3(x, y, this.transform.localPosition.z), Quaternion.identity) as GameObject;
        tmpTerrain.transform.parent = gameObject.transform;
    }

    void createTerrainSprite(int i, int j)
    {
        GameObject image = one;
        try
        {
                int rand = UnityEngine.Random.Range(0, 4);
                if (rand == 0) image = zero;
                else if (rand == 1) image = one;
                else if (rand == 2) image = two;
                else image = three;
        } catch (Exception e)
        {

        }

        float x = Math.Abs((width/2)-i) * 0.74f;
        if (i < (width / 2)) x *= (-1);
        float y = Math.Abs((height / 2) - j) * 0.74f;
        if (j < (height / 2)) y *= (-1);

        GameObject tmpTerrain = Instantiate(image, new Vector3(x,y,this.transform.localPosition.z), Quaternion.identity) as GameObject;
        tmpTerrain.transform.parent = gameObject.transform;
    }
}
