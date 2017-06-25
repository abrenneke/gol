﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class World : MonoBehaviour
    {
        public static World Instance { get; private set; }

        public GameObject MainCamera { get; private set; }

        private IDictionary<string, GolObject> objects;

        public GolObject Rock { get { return Get("Rock"); } }

        public GolObject Magic { get { return Get("Magic"); } }

        public GolObject Kitten { get { return Get("Kitten"); } }

        public GameObject Ded;

        public ICollection<GolObject> Interactables
        {
            get
            {
                var interactables = new List<GolObject>();
                if( Rock != null)
                    interactables.Add(Rock);
                if(Magic != null)
                    interactables.Add(Magic);
                if(Kitten != null)
                    interactables.Add(Kitten);
                return interactables;
            }
        }

        public void Awake()
        {
            objects = new Dictionary<string, GolObject>();
            Instance = this;

            MainCamera = GameObject.Find("ARCamera");
        }

        public void Start()
        {
            Ded.SetActive(false);
        }

        public static void Register(GolObject golObject, string name)
        {
            Instance.objects[name] = golObject;
        }

        public static GolObject Get(string name)
        {
            GolObject obj;
            Instance.objects.TryGetValue(name, out obj);
            return obj;
        }

        public void Dead()
        {
            Ded.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}