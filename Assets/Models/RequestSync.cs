using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestSync : RealtimeComponent<RequestSyncModel>
{
    private string _translation;
    private bool _requested;

    private string _Suggestions;

    private void Awake()
    {
        //_translation = GetComponent<string>();
        _requested = false;
    }

    protected override void OnRealtimeModelReplaced(RequestSyncModel previousModel, RequestSyncModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.translationDidChange -= TranslationStringDidChange;
            previousModel.requestedDidChange -= RequestedDidChange;
            previousModel.suggestionsDidChange -= SuggestionsDidChange;
        }
        if (currentModel.isFreshModel)
        {
            currentModel.translation = _translation;
            currentModel.requested = _requested;
            currentModel.suggestions = _Suggestions;
        }

        UpdateTranslationString();
        UpdateRequested();
        UpdateSuggestions();


        currentModel.translationDidChange += TranslationStringDidChange;
        currentModel.requestedDidChange += RequestedDidChange;
        currentModel.suggestionsDidChange += SuggestionsDidChange;
    }

    private void TranslationStringDidChange(RequestSyncModel model, string translationString)
    {
        UpdateTranslationString();
    }

    private void RequestedDidChange(RequestSyncModel model, bool requested)
    {
        UpdateTranslationString();
    }
    public void SuggestionsDidChange(RequestSyncModel model, string suggestions)
    {
        UpdateSuggestions();
    }

    private void UpdateTranslationString()
    {
        _translation = model.translation;
    }

    private void UpdateRequested()
    {
        _requested = model.requested;
    }

 
    public void UpdateSuggestions()
    {
        _Suggestions = model.suggestions;
    }
    

    public void SetTranslation(string translation)
    {
        model.translation = translation;
    }

    public string GetTranslation()
    {
        return model.translation;
    }

    public void SetRequested(bool requested)
    {
        model.requested = requested;
    }

    public bool GetRequested()
    {
        return model.requested;
    }
    public void SetSuggestions(string suggestions)
    {
        model.suggestions = suggestions;
    }
    public string GetSuggestions()
    {
        return model.suggestions;
    }
    


}
