using CppSharp;
using System;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ConsoleDriver.Run(new SokolLib());
// See https://aka.ms/new-console-template for more information
var passAction = new Sokol.SgPassAction() {
    StartCanary = 0,
    EndCanary = 0
};


Sokol.sokol_app.SappRun(new Sokol.SappDesc(){
    InitCb = InitCallback,
    FrameCb = FrameCallback,
    CleanupCb = CleanupCallback, 
    EventCb = EventCallback,
    Width = 1280,
    Height = 720,
    SampleCount = 4,
    SwapInterval = 1,
    ClipboardSize = 0,
    MaxDroppedFiles = 0,
    MaxDroppedFilePathLength = 0,
    GlMajorVersion = 4,
    GlMinorVersion = 1,
    EnableClipboard = false, //dont check clipboard for now 
    Icon = new Sokol.SappIconDesc(){
        SokolDefault = true
    },
    WindowTitle = "SOKOL WINDOW"
});


void InitCallback()
{
    Console.WriteLine("init");
    Sokol.sokol_gfx.SgSetup(new Sokol.SgDesc(){
        Context = new Sokol.SgContextDesc(){},
        BufferPoolSize = 128,
        ImagePoolSize = 128,
        ShaderPoolSize = 32,
        PipelinePoolSize = 64,
        ContextPoolSize = 16,
        SamplerCacheSize = 64,
        StartCanary = 0,
        EndCanary = 0,
    });

    passAction.Colors[0].Action = Sokol.SgAction.SG_ACTION_CLEAR;
    passAction.Colors[0].Value = new Sokol.SgColor(){
        R = 1.0f,
        G = 0f,
        B = 0f,
        A = 1.0f,
    };
    //     Action = Sokol.SgAction.SG_ACTION_CLEAR,
    //     Value = new Sokol.SgColor(){
    //         R = 1.0f,
    //         G = 0f,
    //         B = 0f,
    //         A = 1.0f,
    //     }
    // };

}

void EventCallback(IntPtr ptr)
{
    var s = Sokol.SappEvent.__GetOrCreateInstance(ptr);
    Console.WriteLine($"event cb:  {s.Type}");
}

void CleanupCallback()
{
    Sokol.sokol_gfx.SgShutdown();
    Console.WriteLine("cleanup called");
}

void FrameCallback()
{
    var g = passAction.Colors[0].Value.G + 0.1f;
    passAction.Colors[0].Value.G = g > 1.0f ? 0f : g;
    // passAction.Colors[0].Value = new Sokol.SgColor(){
    //     R = 1.0f,
    //     G = g,
    //     B = 0f,
    //     A = 1.0f,
    // };
    // passAction.Colors[0].Action = Sokol.SgAction.SG_ACTION_CLEAR;
    // Sokol.sokol_gfx.SgBeginDefaultPass(passAction,Sokol.sokol_app.SappWidth(),Sokol.sokol_app.SappHeight());
    Sokol.sokol_gfx.SgBeginDefaultPass(passAction,Sokol.sokol_app.SappWidth(),Sokol.sokol_app.SappHeight());
    Sokol.sokol_gfx.SgEndPass();
    Sokol.sokol_gfx.SgCommit();
    Console.WriteLine("frame called");
}