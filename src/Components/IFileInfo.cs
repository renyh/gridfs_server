﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GridFSServer.Components
{
    internal interface IFileInfo : IDisposable
    {
        string Filename { get; }

        Task<bool> CopyTo(Stream stream, CancellationToken cancellationToken);
    }
}
