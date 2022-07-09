using CppSharp;
using System;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ConsoleDriver.Run(new SokolLib());
// See https://aka.ms/new-console-template for more information

Sokol.sokol_app.SappRun(new Sokol.SappDesc(){
    InitCb = () => {
        Console.WriteLine("init");
        // Sokol.sokol_gfx.SgSetup(new Sokol.SgDesc(){
        //     Context = new Sokol.SgContextDesc(){}
        // });
    },
    FrameCb = FrameCallback,
    CleanupCb = CleanupCallback, 
    EventCb = (ptr) => {
        Console.WriteLine("event cb");
    },
    Width = 1280,
    Height = 720,
    SampleCount = 4,
    SwapInterval = 1,
    ClipboardSize = 0,
    MaxDroppedFiles = 0,
    MaxDroppedFilePathLength = 0,
    GlMajorVersion = 4,
    GlMinorVersion = 1,
    Icon = new Sokol.SappIconDesc(){
        SokolDefault = true
    },
    WindowTitle = "SOKOL WINDOW"
});

static void EventCallback(IntPtr ptr)
{
    Console.WriteLine("event cb");
}

static void CleanupCallback()
{
    // Sokol.sokol_gfx.SgShutdown();
    Console.WriteLine("cleanup called");
}

static void FrameCallback()
{
    // var passAction = new Sokol.SgPassAction();
    // passAction.Colors[0] = new Sokol.SgColorAttachmentAction(){
    //     Action = Sokol.SgAction.SG_ACTION_CLEAR,
    //     Value = new Sokol.SgColor(){
    //         R = 1.0f,
    //         G = 0f,
    //         B = 0f,
    //         A = 1.0f,
    //     }
    // };
    // Sokol.sokol_gfx.SgBeginDefaultPass(passAction,Sokol.sokol_app.SappWidth(),Sokol.sokol_app.SappHeight());
    // Sokol.sokol_gfx.SgEndPass();
    // Sokol.sokol_gfx.SgCommit();
    Console.WriteLine("frame called");
}