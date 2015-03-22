using System;

public class CSharpExam : Exam
{
    private const byte MinScore = 0;
    private const byte MaxScore = 100;

    public CSharpExam(int score)
    {
        if (score < MinScore)
        {
            throw new ArgumentOutOfRangeException("Score must be zero or positie number");
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult Check()
    {
        if (this.Score < MinScore || this.Score > MaxScore)
        {
            throw new ArgumentOutOfRangeException("Score must be in range [1-99]");
        }
        else
        {
            return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
        }
    }
}
