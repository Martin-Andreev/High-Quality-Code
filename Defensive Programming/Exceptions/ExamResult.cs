using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Grade must be zero or positive number.");
            }

            this.grade = value;
        }
    }

    public int MinGrade {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("MinGrade must be zero or positive number.");
            }

            this.minGrade = value;
        } 
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
            
        }

        private set
        {
            if (value <= this.minGrade)
            {
                throw new ArgumentOutOfRangeException("MaxGrade must be equal or greater than minGrade.");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
            
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException("Comments cannot be null or empty.");
            }

            this.comments = value;
        }
    }
}
