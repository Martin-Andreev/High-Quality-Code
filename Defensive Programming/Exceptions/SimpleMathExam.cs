using System;
using System.Runtime.InteropServices;

public class SimpleMathExam : Exam
{
    private const byte MinProblemsSolved = 0;
    private const byte MaxProblemsSolved = 10;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < MinProblemsSolved || value > MaxProblemsSolved)
            {
                throw new ArgumentOutOfRangeException("problemSolved", "SimpleMathExam problemSolved must be in range [0-10].");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        switch (this.ProblemsSolved)
        {
            case 1:
            case 2:
                return new ExamResult(2, 2, 6, "Poor result: nothing done.");
            case 3:
            case 4:
                return new ExamResult(3, 2, 6, "Bad result: few problems solved.");
            case 5:
            case 6:
                return new ExamResult(4, 2, 6, "Average result: some problems solved.");
            case 7:
            case 8:
                return new ExamResult(5, 2, 6, "Very good result: almost every problem solved.");
            case 9:
            case 10:
                return new ExamResult(6, 2, 6, "Excellent result: most or all problems solved.");
            default:
                throw new ArgumentOutOfRangeException("problemSolved", "SimpleMathExam check has invalid numbers argument.");
        }
    }
}
