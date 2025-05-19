    async void Start()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl(Url, opts => {
                // JWT 필요 시:
                // opts.AccessTokenProvider = () => Task.FromResult("<token>");
            })
            .WithAutomaticReconnect()
            .Build();

        _connection.On<string>("PlayerJoined", id    => Debug.Log($"{id} joined"));
        _connection.On<string>("PlayerLeft",   id    => Debug.Log($"{id} left"));
        _connection.On<string,object>("ReceivePlayerState", (id, state) => {
            // state 파싱 후 해당 플레이어 업데이트
        });

        await _connection.StartAsync();
        await _connection.InvokeAsync("JoinRoom", Room);
    }
