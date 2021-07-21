using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private SceneFader fader;
    private List<Orb> orbs;
    public int orbNum;
    public int deathNum;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        orbs = new List<Orb>();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        orbNum = instance.orbs.Count;
    }

    public static void RegisterSceneFader(SceneFader obj)
    {
        instance.fader = obj;
    }

    public static void RegisterOrb(Orb orb)
    {
        if (!instance.orbs.Contains(orb))
        {
            instance.orbs.Add(orb);
        }
    }

    public static void PlayerGrabbedOrb(Orb orb)
    {
        if(!instance.orbs.Contains(orb))
            return;
        instance.orbs.Remove(orb);
    }

    public static void PlayerDied()
    {
        instance.fader.FadeOut();
        instance.deathNum++;
        instance.Invoke("RestartScene", 1.5f);     
    }

    void RestartScene()
    {
        instance.orbs.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
