# Unlocker
Genshin Impact FPS Unlocker.

## Warning

For study usage only!!!

## Usage

Unlock the FPS settings (V-sync needs to be manually turn off by user.)
```c#
// Get a game process.
Process gameProcess = new(...);

// use the process
GameFpsUnlocker unlocker = new(gameProcess, 144);

// Start the game process.
gameProcess.Start();

// prepare the arguments.
TimeSpan find = TimeSpan.FromMilliseconds(100);
TimeSpan limit = TimeSpan.FromMilliseconds(10000);
TimeSpan adjust = TimeSpan.FromMilliseconds(2000);

// unlock fps and wait for the process exit.
// Exception will throw immediately when occurs.

try
{
    await unlocker.UnlockAsync(find, limit, adjust);
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
unlocker.TargetFPS = 120;
```

## Implementation Detail

The unlocker runs a loop internally to keep track with the FPS memory location for the UnityPlayer.dll.  
Which deal a bit performance impact for the user.  

So adjust operation is not recommand to set too frequently.