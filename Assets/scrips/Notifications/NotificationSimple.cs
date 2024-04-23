using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class NotificationSimple : MonoBehaviour
{
    public static NotificationSimple instance { get; private set; }
    private const string idCanal = "canalNotificacion";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);

        }
    }


    private void Start()
    {
#if UNITY_ANDROID
        RequestAuhtorization();
        RegisterNotificationChannel();
#endif
    }

#if UNITY_ANDROID
    //Request authorization to send notifications
    public void RequestAuhtorization()
    {
        if(!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    //Register a Notification Channel
    public void RegisterNotificationChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel
        {
            Id = "default_channel",
            Name = "Default",
            Importance = Importance.Default,
            Description = "Notifications"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }




    //Set Up Notification Template
    public void SendNotification(string title, string text, int fireTimeInHours, bool Gano)
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = DateTime.Now.AddHours(fireTimeInHours);
        notification.SmallIcon = "icon_0";
        if(Gano)
        notification.LargeIcon = "icon_1";
        else
        notification.LargeIcon = "icon_2";

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }




    public void ButtonFunction()
    {
        SendNotification("Dummy Notification", "This is a sample Notification", 0, true);
    }
#endif
}
