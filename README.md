# Void Save System for Unity
Because saving your game data shouldn't be a pain in the... inspector.
This plugin is your chill, plug-and-play way to save and load anything in unity -- encrypted, flexible, and friendly to both pros and prototype warriors. It doesn't matter if u're saving coins, player stats, or idk... interdimensional taco recipes? We got your back ;D

## What makes it good?
* **Clean and modular** -- Built on SOLID principles. You can swap components like lego bricks
* **Encrypted by default** -- AES-256 so cheaters can't poke around your save files like it’s christmas morning 😅
* **One-liners for everything** -- `VoidSave.Save(...)` and boom, done.
* **Extremely extendable** -- Want Protobuf instead of JSON? Your own save path? No problem c:
* **Zero setup needed** -- Just drop it in, write a serializable class, and you're rolling 🎉

## Installing

1. Drop the `VoidSaveSystem` folder anywhere inside `Assets/Plugins/`.
2. Add `using VoidSaveSystem;` to your scripts.
3. Done. Seriously.

(Optionally replace the AES key in `SaveServiceFactory` with your own 32-byte secret if you want extra security. Totally optional... but, you know, safety's never enough)

## Quick Start Guide

### 1. Define your save data

```csharp
[Serializable]
public class PlayerProgress
{
    public int coins;
    public string currentLevel;
    public Vector3 playerPosition;
}
```

### 2. Save some stuff

```csharp
var progress = new PlayerProgress {
    coins = 42,
    currentLevel = "Level_1",
    playerPosition = player.transform.position
};

VoidSave.Save("slot1", progress);
```

### 3. Load it later

```csharp
if (VoidSave.Exists<PlayerProgress>("slot1")) {
    var loaded = VoidSave.Load<PlayerProgress>("slot1");
    player.transform.position = loaded.playerPosition;
}
```

### 4. Delete when you're done messing around

```csharp
VoidSave.Delete<PlayerProgress>("slot1");
```

## Full Example Script

Paste this into a script like `SaveExample.cs` and attach it to any GameObject:

```csharp
using UnityEngine;
using VoidTools.SaveSystem;

public class SaveExample : MonoBehaviour
{
    [SerializeField] private string slotName = "slot1";
    private PlayerProgress progress;

    void Start()
    {
        if (VoidSave.Exists<PlayerProgress>(slotName))
        {
            progress = VoidSave.Load<PlayerProgress>(slotName);
            transform.position = progress.playerPosition;
            Debug.Log($"[Loaded] Coins: {progress.coins}, Level: {progress.currentLevel}");
        }
        else
        {
            progress = new PlayerProgress {
                coins = 0,
                currentLevel = "Tutorial",
                playerPosition = transform.position
            };
            Debug.Log("[New Save] Starting fresh!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            progress.playerPosition = transform.position;
            progress.coins += 5;
            VoidSave.Save(slotName, progress);
            Debug.Log("[Saved] Progress updated.");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            VoidSave.Delete<PlayerProgress>(slotName);
            Debug.Log("[Deleted] Save wiped.");
        }
    }
}

[System.Serializable]
public class PlayerProgress
{
    public int coins;
    public string currentLevel;
    public Vector3 playerPosition;
}
```

## Wanna customize stuff?

* Make your own **serializer** by implementing `ISerializer` (e.g, Protobuf, XML... whatever u vibe with)
* Roll your own **encryption** via `IEncryptionService`
* Change file paths or extensions with a custom `IFileHandler`
* Or ditch `VoidSave` and inject things manually using `SaveService<T>` if you're feeling fancy

## Pro Mode: Extend It!

```csharp
// Plug in your own serializer
var saveService = new SaveService<PlayerProgress>(
    new MyCustomSerializer(),
    new AesEncryptionService("your-base64-key"),
    new PersistentFileHandler("MySaves", ".awesome")
);

saveService.Save("slot42", new PlayerProgress { coins = 999 });
```

## 🖤 Thanks!

If this plugin saved your butt (or at least your game's data), give it a ⭐ 😅

Built with love, coffee, and too many saves lost to `PlayerPrefs`. ☕
