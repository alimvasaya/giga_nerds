
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class RequestSyncModel
{
    [RealtimeProperty(1, true, true)] private string _translation;

    [RealtimeProperty(2, true, true)] private bool _requested;

    [RealtimeProperty(3, true, true)] private string _suggestions;
}
