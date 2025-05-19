    async void Start()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl(Url, opts => {
            })
            .WithAutomaticReconnect()
            .Build();

        _connection.On<string>("PlayerJoined", id    => Debug.Log($"{id} joined"));
        _connection.On<string>("PlayerLeft",   id    => Debug.Log($"{id} left"));
        _connection.On<string,object>("ReceivePlayerState", (id, state) => {
        });

        await _connection.StartAsync();
        await _connection.InvokeAsync("JoinRoom", Room);
    }
