    public async void SendState(object state)
    {
        if (_connection.State == HubConnectionState.Connected)
            await _connection.InvokeAsync("BroadcastPlayerState", Room, state);
    }
