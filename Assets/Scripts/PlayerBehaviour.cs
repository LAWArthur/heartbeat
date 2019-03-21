using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Failure()
    {
        PostProcessingProfile profile = GameObject.Find("/Player/FirstPersonCharacter").AddComponent<PostProcessingBehaviour>().profile = new PostProcessingProfile();
        profile.colorGrading.enabled = true;
        ColorGradingModel.Settings settings = profile.colorGrading.settings;
        settings.channelMixer = new ColorGradingModel.ChannelMixerSettings();
        for(int i = 0;i < 50; i++)
        {
            settings.channelMixer.blue = Vector3.Lerp(new Vector3(0, 0, 1), Vector3.one, (float)i / 50);
            settings.channelMixer.red = Vector3.Lerp(new Vector3(1, 0, 0), Vector3.one, (float)i / 50);
            settings.channelMixer.green = Vector3.Lerp(new Vector3(0, 1, 0), Vector3.one, (float)i / 50);
            profile.colorGrading.settings = settings;
            yield return new WaitForSecondsRealtime(0.02f);
        }

        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene(0);
    }
}
