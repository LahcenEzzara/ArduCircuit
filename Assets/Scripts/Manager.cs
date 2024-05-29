using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
  int index = 0;
  public List<Texture2D> images;
  public Button button;
  public RawImage imageFrame;
  void Start()
  {
    GameObject buttonGameObject = GameObject.FindWithTag("NextButton");
    button = buttonGameObject?.GetComponent<Button>(); // Add null check here
    if (button != null)
    {
      button.onClick.AddListener(() =>
      {
        nextImage();
        Debug.Log("Button Clicked");
      });
    }
    else
    {
      Debug.LogError("Button not found");
    }
    for (int i = 1; i <= 2; i++)
    {
      Texture2D texture = Resources.Load<Texture2D>("Images/capture" + i);
      images.Add(texture);
    }

    GameObject imageGameObject = GameObject.FindWithTag("ImageFrame");
    imageFrame = imageGameObject?.GetComponent<RawImage>(); // Add null check here

    if (imageFrame != null)
    {
      Debug.Log("ImageFrame found");
    }
    else
    {
      Debug.LogError("ImageFrame not found");
    }
  }

  void nextImage()
  {
    index++;
    if (index >= images.Count)
    {
      index = 0;
    }
    imageFrame.texture = images[index];
  }

  // Update is called once per frame
  void Update()
  {

  }
}
