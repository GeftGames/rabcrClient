namespace rabcrClient {
    public enum Command : byte {
        Null,
        CheckInMenu,       //Status of server
        Check,         //Status of server
        Blank,

        // Starting
        GetStatus,     // get req to join
        Login,         // Login into the server with pasword (or without)
        LoggedState,   // Server say ok or wrong
        SetPassword,   // Set password enter
        Logout,        // Logout of the server
        Exit,          // End
        Message,       // Send a text message to all the chat clients

        // World
        SendingWorldData,      //Get chunk of blocks
        GetWorldData,
        ListPlayersPositions,  //get pos of player

        Request,               // Check if player exists
        EditTerrain,

        // Others
        PlayersList,   // Get a list of users in the chat room from the server
        SomeoneLogout,
        ConnectDuringGame,
        PlayersTeleportMessageToTarget,
        PlayersTeleportMessageToSource,

        // Player data
        PlayerBasicStates, // lives, food, water, ...
        PlayerInventory,   // my inv, ...
        EatFood,
        SetInventory,
        SetInventoryMachine,
        SpawnChanged,
        PlayerPosition,
        JoinWorld,

    }

    enum ErrorJoinWorld {
        None,
        NotAllowedToJoin,
        NotFound,
    }
}
