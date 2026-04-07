namespace Frameworks2.Services
{
    public interface IScoreStorage
    {
        void AddOrUpdateScore(string playerName, int score);
        IReadOnlyDictionary<string, int> GetAllScores();
    }
}
