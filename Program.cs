using CppSharp;
using System;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
// ConsoleDriver.Run(new SokolLib());
// See https://aka.ms/new-console-template for more information
// var x = new Sokol.sokol_app.

// while(true)
// unsafe
// {
    using(var desc = new Sokol.SappDesc(){
        InitCb = InitCallback,
        FrameCb = FrameCallback,
        CleanupCb = CleanupCallback,
        EventCb = EventCallback,
        Width = 1280,
        Height = 720,
        SampleCount = 4,
        WindowTitle = "SOKOL WINDOW",
    })
    {
        Sokol.sokol_app.SappRun(desc);
    }
    // var desc = new Sokol.SappDesc(){
    //     InitCb = InitCallback,
    //     FrameCb = FrameCallback,
    //     CleanupCb = CleanupCallback,
    //     EventCb = EventCallback,
    //     Width = 1280,
    //     Height = 720,
    //     SampleCount = 4,
    //     WindowTitle = "SOKOL WINDOW",
    // };
    // GCHandle gch = GCHandle.Alloc(desc,GCHandleType.Weak);
    // GCHandle gch = GCHandle.FromIntPtr(desc.__Instance);
    // Sokol.sokol_app.SappRun(desc);
    // GC.SuppressFinalize(desc);
    // while(true)
    // {

    // }


    static void EventCallback(IntPtr ptr)
    {
        Console.WriteLine("event cb");
    }

    static void CleanupCallback()
    {
        Console.WriteLine("cleanup called");
    }

    // [UnmanagedCallersOnly]
    static void InitCallback()
    {
        // unsafe
        // {
        //     Sokol.sokol_gfx.SgSetup(new Sokol.SgDesc(){
        //         Context = new Sokol.SgContextDesc(){}
        //     });
        // }
        Console.WriteLine("init called");
        var gfxDesc = new Sokol.SgDesc(){
            Context = new Sokol.SgContextDesc(){}
        };
        // GCHandle gch_gfx = GCHandle.Alloc(gfxDesc,GCHandleType.Pinned);
        Sokol.sokol_gfx.SgSetup(gfxDesc);
    }

    static void FrameCallback()
    {
        Console.WriteLine("frame called");
    }

// }