using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeibaScrapingMock
{
    [JsonObject]
    struct LoginData
    {
        [JsonProperty("mail")]
        public string MailAddress { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    };
    internal struct Horse
    {
        public string Mark { get; set; }
        public int Frame { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string SexAge { get; set; }
        public string Weight { get; set; }
        public string Jockey { get; set; }
        public double Odds { get; set; }
        public int Popular { get; set; }
        public int Before1Score { get; set; }
        public int Before2Score { get; set; }
        public int Before3Score { get; set; }
        public int Before4Score { get; set; }
        public int Before5Score { get; set; }
        public int DataScore { get; set; }
        public int JockeyScore { get; set; }
        public int TrainingScore { get; set; }
        public int FrameScore { get; set; }
        public int PositionScore { get; set; }
        public int OtherScore { get; set; }
    }

    internal class Model
    {
    }
}
