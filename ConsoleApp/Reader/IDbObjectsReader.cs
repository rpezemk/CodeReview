namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;

    public interface IDbObjectsReader : IDisposable
    {
        List<DbObject> GetDbObjects();
    }

}
