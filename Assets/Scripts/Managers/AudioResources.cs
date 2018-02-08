using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum AmbientalMusic
{
	SaveSound,
}

public class AudioResources : MonoBehaviour
{

    public AudioSource collect_coin;
    public AudioSource shoot_ball;
	public AudioSource target_break;
	public AudioSource backgroundMusic;
	public AudioSource[] ambientalMusic;

	public static AudioResources Instance;

	void Start()
	{
		Instance = this;
	}
}