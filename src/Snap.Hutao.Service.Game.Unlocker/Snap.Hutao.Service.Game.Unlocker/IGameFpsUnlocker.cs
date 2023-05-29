// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

namespace Snap.Hutao.Service.Game.Unlocker;

/// <summary>
/// 游戏帧率解锁器
/// </summary>
public interface IGameFpsUnlocker
{
    /// <summary>
    /// 目标帧率
    /// 在游戏过程中调整此值以动态更改帧率
    /// 默认为 60
    /// </summary>
    int TargetFps { get; set; }

    /// <summary>
    /// 异步的解锁帧数限制
    /// </summary>
    /// <param name="options">选项</param>
    /// <returns>解锁的结果</returns>
    Task UnlockAsync(UnlockTimingOptions options);
}