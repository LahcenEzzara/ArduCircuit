using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class Manager : MonoBehaviour
{
  int index = 0;
  bool firstTimeDetected = true;
  // public List<Texture2D> images;
  public List<VideoClip> videos;
  public List<string> stepList;
  public Button nextButton;

  public Button prevButton;
  public RawImage imageFrame;
  public TextMeshProUGUI textStep;
  public VideoPlayer videoPlayer;

  public void onModelDetected()
  {
    Debug.Log("Model Detected");
    if (firstTimeDetected)
    {
      firstTimeDetected = false;
      videoPlayer.clip = videos[index];
    }
    videoPlayer.Play();
  }

  public void onModelLost()
  {
    Debug.Log("Model Lost");
    videoPlayer.Stop();
  }

  void Start()
  {
    stepList = new List<string> { "Connect the other end of the resistor using jumper wire", "Connect the resistor to digital pin 13 of the Arduino", "Connect the short leg of the LED (cathode) using a jumper wire", "Connect the LED to the GND (Ground) pin of the Arduino", "Demo" };

    textStep = GameObject.FindWithTag("TextStep").GetComponent<TextMeshProUGUI>();
    textStep.text = stepList[index];

    GameObject nextButtonGameObject = GameObject.FindWithTag("NextButton");
    GameObject prevButtonGameObject = GameObject.FindWithTag("PrevButton");

    nextButton = nextButtonGameObject?.GetComponent<Button>();
    prevButton = prevButtonGameObject?.GetComponent<Button>();
    if (nextButton != null)
    {
      nextButton.onClick.AddListener(() =>
      {
        nextVideo();
        Debug.Log("Next Button Clicked");
      });
    }
    else
    {
      Debug.LogError("Next Button not found");
    }

    if (prevButton != null)
    {
      prevButton.onClick.AddListener(() =>
      {
        prevVideo();
        Debug.Log("Prev Button Clicked");
      });
      prevButton.interactable = false;
    }
    else
    {
      Debug.LogError("Prev Button not found");
    }

    // for (int i = 1; i <= 2; i++)
    // {
    //   Texture2D texture = Resources.Load<Texture2D>("Images/capture" + i);
    //   images.Add(texture);
    // }

    for (int i = 1; i <= 5; i++)
    {
      VideoClip video = Resources.Load<VideoClip>("Videos/" + i);
      videos.Add(video);
    }

    Debug.Log(videos.Count);

    for (int i = 0; i < 5; i++)
    {
      Debug.Log(videos[i].name);
    }

    // GameObject imageGameObject = GameObject.FindWithTag("ImageFrame");
    // imageFrame = imageGameObject?.GetComponent<RawImage>(); // Add null check here

    // if (imageFrame != null)
    // {
    //   Debug.Log("ImageFrame found");
    // }
    // else
    // {
    //   Debug.LogError("ImageFrame not found");
    // }


    GameObject videoPlayerGameObject = GameObject.FindWithTag("VideoPlayer");
    videoPlayer = videoPlayerGameObject?.GetComponent<VideoPlayer>(); // Add null check here

    if (videoPlayer != null)
    {
      Debug.Log("VideoPlayer found");
    }
    else
    {
      Debug.LogError("VideoPlayer not found");
    }
  }

  // void nextImage()
  // {
  //   index++;
  //   if (index >= images.Count)
  //   {
  //     index = 0;
  //   }
  //   imageFrame.texture = images[index];
  // }

  // void prevImage()
  // {
  //   index--;
  //   if (index < 0)
  //   {
  //     index = images.Count - 1;
  //   }
  //   imageFrame.texture = images[index];
  // }

  void nextVideo()
  {
    index++;
    if (index >= videos.Count)
    {
      index = 0;
    }
    checkButtonState();
    switchVideo();
  }

  void prevVideo()
  {
    index--;
    if (index < 0)
    {
      index = videos.Count - 1;
    }
    checkButtonState();
    switchVideo();
  }

  void checkButtonState()
  {
    if (index == 0)
    {
      prevButton.interactable = false;
    }
    else
    {
      prevButton.interactable = true;
    }

    if (index == videos.Count - 1)
    {
      nextButton.interactable = false;
    }
    else
    {
      nextButton.interactable = true;
    }
  }

  void switchVideo()
  {
    videoPlayer.Stop();
    textStep.text = stepList[index];
    videoPlayer.clip = videos[index];
    videoPlayer.Play();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
