using UnityEngine;
using Code.Audio;
using AudioType = Code.Audio.AudioType;

public class SceneMusicController : MonoBehaviour
{
    [SerializeField] private AudioID musicToPlay;
    [SerializeField] private float fadeInDuration = 0.5f;
    [SerializeField] private bool stopOnExit = true;
    [SerializeField][Range(0, 100)] private float musicVolume = 100f;

    private void Start()
    {
        if (AudioManager.CurrentMusic == musicToPlay)
        {
            Debug.Log($"[SceneMusicController] '{musicToPlay}' already playing, skipping restart.");
            return;
        }

        AudioManager.PlayAudio(musicToPlay, this, fadeInDuration);
        AudioManager.SetVolume(musicVolume, AudioType.Music);
        AudioManager.CurrentMusic = musicToPlay;
    }

    private void OnDestroy()
    {
        if (stopOnExit)
        {
            AudioManager.StopMusic(1f);
            AudioManager.CurrentMusic = default;
        }
    }
}