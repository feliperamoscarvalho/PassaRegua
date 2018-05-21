using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;

namespace PassaRegua
{
    interface IConfig
    {
        string DiretorioDB { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
