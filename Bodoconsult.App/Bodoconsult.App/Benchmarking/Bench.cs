// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Benchmarking
{
    /// <summary>
    /// Log Bench entity class for benchmark viewer https://github.com/crep4ever/benchmark-viewer
    /// </summary>
    public class Bench: IDisposable
    {
        private readonly IAppBenchProxy _proxy;

        private bool Stopped { get; set; }
        private bool Started { get; set; }
        private string Key { get; set; }
        
        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="key"></param>
        /// <param name="comment"></param>
        /// <param name="autoStart"></param>
        public Bench(IAppBenchProxy proxy, string key, string comment="", bool autoStart=true)
        {
            _proxy = proxy;
            Key = key;

            if (autoStart)
            {
                Start(comment);
            }
        }


        /// <summary>
        /// Start benchmark
        /// </summary>
        /// <param name="comment"></param>
        public void Start(string comment)
        {
            Started = true;
            Stopped = false;

            //write
            if (_proxy!=null)
            {
                _proxy.LogStart(Key, comment);
            }
        }


        /// <summary>
        /// Stop benchmark
        /// </summary>
        /// <param name="comment"></param>
        public void Stop(string comment)
        {
            Stopped = true;

            if (_proxy != null)
            {
                _proxy.LogStop(Key, comment);
            }
        }

        /// <summary>
        /// Add Step benchmark
        /// </summary>
        /// <param name="comment"></param>
        public void AddStep(string comment)
        {
            if (_proxy != null && Started && !Stopped)
            {
                _proxy.LogStep(Key, comment);
            }
        }

        /// <summary>
        /// Dto. force Stop benchmark if not stoppped.
        /// It's advised to call it manually to produce the STOP trace when required, and not to wait for garbage collection...later
        /// </summary>
        public void Dispose()
        {
            if (Started && !Stopped)
            {
                Stop("");
            }
        }
    }
}
