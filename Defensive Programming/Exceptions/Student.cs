﻿using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;

        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("firstName", "Student first name cannot be null or emtpy.");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;

        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("lastName", "Student last name cannot be null or emtpy.");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams; 
            
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("exams", "Student exams cannot be null.");
            }

            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams.Count == 0)
        {
            Console.WriteLine("The student has no exams!");
            return null;
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Student CalcAverageExamResultInPercents cannot calculate the average result of an empty list.");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
