// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.ToolHelp;
using static Windows.Win32.PInvoke;

namespace Snap.Hutao.Service.Game.Unlocker;

/// <summary>
/// 结构体封送
/// </summary>
internal static class StructMarshal
{
    /// <summary>
    /// 构造一个新的 <see cref="Windows.Win32.System.Diagnostics.ToolHelp.MODULEENTRY32"/>
    /// </summary>
    /// <returns>新的实例</returns>
    public static unsafe MODULEENTRY32 MODULEENTRY32()
    {
        return new() { dwSize = (uint)sizeof(MODULEENTRY32) };
    }

    /// <summary>
    /// 枚举快照的模块
    /// </summary>
    /// <param name="snapshot">快照</param>
    /// <returns>模块枚举</returns>
    [SupportedOSPlatform("windows5.1.2600")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<MODULEENTRY32> EnumerateModuleEntry32(HANDLE snapshot)
    {
        MODULEENTRY32 entry = MODULEENTRY32();

        if (Module32First(snapshot, ref entry))
        {
            do
            {
                yield return entry;
            }
            while (Module32Next(snapshot, ref entry));
        }
    }
}