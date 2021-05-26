using System;

namespace BL.MaterialPrinterLab
{
    public class ContextConfig
    {
        private readonly string _ConnectionString;

        public ContextConfig(string connectionString)
        {
            _ConnectionString = connectionString;

        }
    }
}
