using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SfxManager : MonoBehaviour
{
    public AudioMixerGroup sfxsMixer;
    public AudioMixerGroup uiMixer;
    AudioSource sfxSource;
    AudioSource uiSource;
    AudioClip addSfx;
    AudioClip levelSfx;
    AudioClip bienSfx;
    AudioClip malSfx;
    // Start is called before the first frame update
    void Start() {
        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.outputAudioMixerGroup = sfxsMixer;
        uiSource = gameObject.AddComponent<AudioSource>();
        uiSource.outputAudioMixerGroup = uiMixer;
        addSfx = Resources.Load<AudioClip>("Audio/drop");
        levelSfx = Resources.Load<AudioClip>("Audio/level");
        bienSfx = Resources.Load<AudioClip>("Audio/bien");
        malSfx = Resources.Load<AudioClip>("Audio/mal");

        Events.newSOAdded += SOAdded;
        Events.LevelComplete += LevelComplete;
        Events.OnCorrect += OnCorrect;
        Events.OnIncorrect += OnIncorrect;
    }
    void OnDestroy() {
        Events.newSOAdded -= SOAdded;
        Events.LevelComplete -= LevelComplete;
        Events.OnCorrect -= OnCorrect;
        Events.OnIncorrect -= OnIncorrect;
    }

    void SOAdded(bool fromDrag) {
        if(fromDrag)
        sfxSource.PlayOneShot(addSfx);
    }

    void LevelComplete() {
        uiSource.PlayOneShot(levelSfx);
    }

    void OnCorrect(SceneObject.types type) {
        sfxSource.PlayOneShot(bienSfx);
    }

    void OnIncorrect(SceneObject.types type) {
        sfxSource.PlayOneShot(malSfx);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

