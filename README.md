# Unlocker
Genshin Impact FPS Unlocker.

## Warning

For study usage only!!!

## Usage

Unlock the FPS settings (V-sync needs to be manually turn off by user.)
```c#
// Prepare game path
string gamePath = "C:/Path/To/Your/Genshin Impact/Genshin Impact Game/YuanShen.exe";

// Get a game process.
Process gameProcess = new()
{
    StartInfo = new()
    {
        FileName = gamePath,
        UseShellExecute = true,
        Verb = "runas",
        WorkingDirectory = Path.GetDirectoryName(gamePath),
    },
};

// use the process
GameFpsUnlocker unlocker = new(gameProcess);

// Start the game process.
gameProcess.Start();

// prepare the arguments.
int find = 100;
int limit = 20000;
int adjust = 3000;
UnlockTimingOptions options = new(find, limit, adjust);

// unlock fps and wait for the process exit.
// Exception will throw immediately when occurs.
try
{
    await unlocker.UnlockAsync(options);
}
catch(Exception ex)
{
    // Handle exception here.
}

```
Adjust FPS dynamically.

```c#
// Set this property on other thread.
// FPS will be adjusted next loop
unlocker.TargetFps = 120;
```

## Implementation Detail

The unlocker runs a loop internally to keep track with the FPS memory location for the UnityPlayer.dll.  
Which deal a bit performance impact for the user.  

So adjust operation is not recommand to set too frequently.
