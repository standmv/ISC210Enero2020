﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using AssemblyCSharp.Assets.Scripts.Exploration.Entities;
using UnityEngine;

public class MapManagement : MonoBehaviour
{
    XmlDocument xmlDocument;
    string xmlPath = "Exploration/Level1_justmap";

    GameObject TilesParent;
    GameObject CharactersParent;
    GameObject ItemsParent;

    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject F;
    public GameObject G;
    public GameObject H;
    public GameObject I;
    public GameObject J;
    public GameObject K;
    public GameObject L;
    public GameObject M;
    public GameObject N;
    public GameObject O;
    public GameObject R;
    public GameObject S;
    public GameObject T;
    public GameObject U;
    public GameObject V;
    public GameObject W;
    public GameObject Y;
    public GameObject Z;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject f;
    public GameObject g;
    public GameObject o;
    public GameObject v;
    public GameObject CoviPrefab;
    public GameObject KnightPrefab;
    public GameObject OfficerPrefab;
    public GameObject ChrisPrefab;
    public GameObject ArisPrefab;
    public GameObject YojaPrefab;
    public GameObject MustacherPrefab;
    public GameObject AileenPrefab;
    public GameObject TorchPrefab;
    public GameObject BarrelPrefab;
    public GameObject MedicalKitPrefab;
    public GameObject BulletsPrefab;
    public GameObject BackPackPrefab;
    public GameObject GunType1Prefab;
    public GameObject GunType2Prefab;
    public GameObject GunType3Prefab;



    //public GameObject ChestSeaweedPrefab;


    private Dictionary<char, GameObject> TilesPrefabs;
    private Dictionary<String, GameObject> CharactersPrefabs;
    private Dictionary<String, GameObject> ItemsPrefabs;

    private void Awake()
    {
        TilesPrefabs = new Dictionary<char, GameObject>
        {
            {'A', A },
            {'B', B },
            {'C', C },
            {'D', D },
            {'E', E },
            {'F', F },
            {'G', G },
            {'H', H },
            {'I', I },
            {'J', J },
            {'K', K },
            {'L', L },
            {'M', M },
            {'N', N },
            {'O', O },
            {'R', R },
            {'S', S },
            {'T', T },
            {'U', U },
            {'V', V },
            {'W', W },
            {'Y', Y },
            {'Z', Z },
            {'a', a },
            {'b', b },
            {'c', c },
            {'d', d },
            {'f', f },
            {'g', g },
            {'o', o },
            {'v', v }
        };

         CharactersPrefabs = new Dictionary<string, GameObject>
         {
             { "CoviPrefab", CoviPrefab },
             {"KnightPrefab", KnightPrefab },
             {"AileenPrefab", AileenPrefab },
             {"YojaPrefab", YojaPrefab },
             {"OfficerPrefab", OfficerPrefab },
             {"ChrisPrefab", ChrisPrefab },
             {"MustacherPrefab", MustacherPrefab },
             {"ArisPrefab", ArisPrefab }
         };
        
         ItemsPrefabs = new Dictionary<string, GameObject>
         {
             {"TorchPrefab", TorchPrefab },
             {"BarrelPrefab", BarrelPrefab },
             {"MedicalKitPrefab", MedicalKitPrefab },
             {"BulletsPrefab", BulletsPrefab },
             {"BackpackPrefab", BackPackPrefab },
             {"GunType1Prefab", GunType1Prefab },
             {"GunType2Prefab", GunType2Prefab },
             {"GunType3Prefab", GunType3Prefab }
         }; 

        xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(Resources.Load<TextAsset>(xmlPath).text);

        //Physics.IgnoreLayerCollision();
        //Vector 3.DiSTANCE
        //Vector3.Moveforward
    }
    // Start is called before the first frame update
    void Start()
    {
        Game.CurrentLevel = new Level();
        TilesParent = GameObject.Find("Tiles");
        CharactersParent = GameObject.Find("Characters");
        ItemsParent = GameObject.Find("Items");
        InitializeMap();
        LoadMap(0, 127, 0, 40);
        LoadCharacters();
        LoadItems();


    }

    void InitializeMap()
    {
        XmlNode mapNode = xmlDocument.SelectSingleNode("/level/map");
        Game.CurrentLevel.Map = new Map(
            Convert.ToInt32(mapNode.Attributes["width"].Value),
            Convert.ToInt32(mapNode.Attributes["height"].Value),
            Convert.ToInt32(mapNode.Attributes["tilewidth"].Value),
            Convert.ToInt32(mapNode.Attributes["tileheight"].Value)
            );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMap(int xFrom, int xTo, int yFrom, int yTo)
    {
        Tile newTile;
        int xFromCopy = xFrom;
        //documentacion de Xpath en W3Schools
        foreach (XmlNode currentNode in xmlDocument.SelectNodes(string.Format("//level/map/row[position() >= {0} and position() <= {1}]", yFrom, yTo)))
        {
            for(xFrom = xFromCopy; xFrom <= xTo; xFrom++)
            {
                newTile = new Tile(TilesPrefabs[currentNode.InnerText[xFrom]], currentNode.InnerText[xFrom] + "," + xFrom.ToString() + "," + yFrom, xFrom, yFrom);
                Game.CurrentLevel.Map.Tiles.Add(newTile);
                newTile.GetObject().transform.SetParent(TilesParent.transform);
            }
            yFrom++;
        }
    }

    public void LoadCharacters()
    {
        Character newCharacter;
        Game.CurrentLevel.Characters = new List<Character>();
        //documentacion de Xpath en W3Schools
        foreach (XmlNode currentNode in xmlDocument.SelectNodes("//level/characters/character"))
        {
            newCharacter = new Character(System.Convert.ToInt32(currentNode.Attributes["id"].Value),
                                         currentNode.Attributes["prefabName"].Value,
                                         currentNode.Attributes["tag"].Value,
                                         CharactersPrefabs[currentNode.Attributes["prefabName"].Value],
                                         currentNode.Attributes["uniqueObjectName"].Value,
                                         System.Convert.ToSingle(currentNode.Attributes["posX"].Value),
                                         System.Convert.ToSingle(currentNode.Attributes["posY"].Value),
                                         System.Convert.ToInt32(currentNode.Attributes["coins"].Value)

                );
            Game.CurrentLevel.Characters.Add(newCharacter);
            newCharacter.GetObject().transform.SetParent(CharactersParent.transform);
            if (newCharacter.Tag == "Player")
            {
                Camera.main.transform.SetParent(newCharacter.GetObject().transform);
                Camera.main.transform.localPosition = new Vector3(0, 0, Camera.main.transform.position.z);
                newCharacter.GetObject().GetComponent<ExplorationPlayerController>().Coins = newCharacter.Coins;
            }
           
        }

    }

    public void LoadItems()
    {
        Item newItem;
        Game.CurrentLevel.Items = new List<Item>();
        //documentacion de Xpath en W3Schools
        foreach (XmlNode currentNode in xmlDocument.SelectNodes("//level/items/item"))
        {
            newItem = new Item(System.Convert.ToInt32(currentNode.Attributes["id"].Value),
                                         currentNode.Attributes["prefabName"].Value,
                                         currentNode.Attributes["tag"].Value,
                                         ItemsPrefabs[currentNode.Attributes["prefabName"].Value],
                                         currentNode.Attributes["uniqueObjectName"].Value,
                                         System.Convert.ToSingle(currentNode.Attributes["posX"].Value),
                                         System.Convert.ToSingle(currentNode.Attributes["posY"].Value),
                                         System.Convert.ToInt32(currentNode.Attributes["price"].Value)

                );
            Game.CurrentLevel.Items.Add(newItem);
            newItem.GetObject().transform.SetParent(ItemsParent.transform);
            if (newItem.Tag == "Stock")
            {
                newItem.GetObject().GetComponent<StoreItemsController>().Price = newItem.Price;
            }
        }

    }
}
