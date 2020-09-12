using Exiled.API.Interfaces;

namespace Bobux
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public string DBPath { get; set; } = "bobux.db";
    }
}