using CppSharp;
using System;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ConsoleDriver.Run(new SokolLib());
// See https://aka.ms/new-console-template for more information
// var x = new Sokol.sokol_app.

// while(true)
// unsafe
// {


    Sokol.sokol_app.SappRun(new Sokol.SappDesc(){
        InitCb = () => {
            Console.WriteLine("init");
            Sokol.sokol_gfx.SgSetup(new Sokol.SgDesc(){
                Context = new Sokol.SgContextDesc(){}
            });
        },
        FrameCb = FrameCallback,
        CleanupCb = CleanupCallback, 
        EventCb = EventCallback,
        Width = 1280,
        Height = 720,
        SampleCount = 4,
        WindowTitle = "SOKOL WINDOW",
    });
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
        Sokol.sokol_gfx.SgShutdown();
        Console.WriteLine("cleanup called");
    }

    // [UnmanagedCallersOnly]
    // static void InitCallback() //doesn't work, needs to be in function itself?
    // {
    //     // unsafe
    //     // {
    //     //     Sokol.sokol_gfx.SgSetup(new Sokol.SgDesc(){
    //     //         Context = new Sokol.SgContextDesc(){}
    //     //     });
    //     // }
    //     Console.WriteLine("init called");
    //     var gfxDesc = new Sokol.SgDesc(){
    //         Context = new Sokol.SgContextDesc(){}
    //     };
    //     // GCHandle gch_gfx = GCHandle.Alloc(gfxDesc,GCHandleType.Pinned);
        
    // }

    static void FrameCallback()
    {
        var passAction = new Sokol.SgPassAction();
        passAction.Colors[0] = new Sokol.SgColorAttachmentAction(){
            Action = Sokol.SgAction.SG_ACTION_CLEAR,
            Value = new Sokol.SgColor(){
                R = 1.0f,
                G = 0f,
                B = 0f,
                A = 1.0f,
            }
        };
        Sokol.sokol_gfx.SgBeginDefaultPass(passAction,Sokol.sokol_app.SappWidth(),Sokol.sokol_app.SappHeight());
        Sokol.sokol_gfx.SgEndPass();
        Sokol.sokol_gfx.SgCommit();
        Console.WriteLine("frame called");
    }

// }