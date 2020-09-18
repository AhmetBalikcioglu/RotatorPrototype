﻿using System;
using UnityEngine.Audio;
using UnityEngine;

// Bu sınıfta ses elementleri kontrol ediliyor
public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;


    void Awake()
    {
        //Oldugumuz sahnede başka AudioManager yok ise bunu atıyoruz varsa bunu siliyoruz.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        //Sounds dizimizin içindeki her sesin atamalarını yapıyoruz.
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    //Başlangıçta müziği çalmaya başlıyoruz.
    void Start()
    {
        Play("Theme");
    }

    //İsmini verdiğimiz müziği çalan fonksiyon
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    //İsmini verdiğimiz sesin açık olup olmama durumuna göre ses düzeyini 0 ile 0.1 arasında değiştiriyoruz.
    public void ChangeVolume(string name, bool isOn)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        if (isOn)
        {
            s.source.volume = 0f;
        }
        else
        {
            s.source.volume = 0.1f;
        }
        
    }
}
