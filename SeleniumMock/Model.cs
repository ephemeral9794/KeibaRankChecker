namespace SeleniumMock
{
    internal struct Horse
    {
        public string Mark { get; set; }
        public int Frame { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string SexAge { get; set; }
        public double Weight { get; set; }
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
        public string Remarks { get; set; }

        public override string ToString()
        {
            return $"{Frame,-2} | {Number,-2} | {Name.PadRight(9, '　')} | {SexAge} | {string.Format("{0:F1}", Weight),-4} | {Jockey.PadRight(5, '　')} | {string.Format("{0:F1}", Odds),-5} | {Popular,-2}";
        }
    }

    internal class Model
    {
    }
}
